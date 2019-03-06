using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Liminal.Core.Fader;
using Liminal.SDK.Core;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    [Space]
    public List<PlanetController> AllPlanetControllers;

    [Header("Experience Length Details:")]
    public float ExperienceLength;
    [Range(0,1)]
    public float NormalizedTime;
    private float m_TimeRemaining;
    public SystemState CurState;

    [Header("Planet Scale and Material Variables:")]
    
    [SerializeField] private List<Vector3> _planetScales;
    [SerializeField] private List<Material> _planetMaterials;
    [SerializeField] private GameObject _uiCanvas;
    [SerializeField] private GameObject _uiPlanet;
    public GameObject SelectedPlanet;

    [Header("Managers:")]
    public IntroManager IntroMan;
    public HeartbeatManager HeartMan;

    [System.Serializable]
    public enum SystemState
    {
        Paused,
        Revealing,
        Playing,
        Ending,
        Ended,
    };

    public delegate void PlanetStatChanged();
    public PlanetStatChanged PlanetStatWasChanged;

    void OnEnable ()
    {
        Instance = this;

        IntroMan = GetComponent<IntroManager>();
        HeartMan = GetComponent<HeartbeatManager>();

        IntroMan.Init();

        CurState = SystemState.Revealing;

        StartCoroutine(CountdownTimer());
    }

    public void SelectPlanet(GameObject selectedPlanet)
    {
        SelectedPlanet = selectedPlanet;

        _uiCanvas.SetActive(true);
        _uiCanvas.GetComponent<InteractableUIController>().Init();
    }

    public void SetPlanetScale(int index, float lerpTime = 1)
    {
        if (index >= _planetScales.Count)
        {
            return;
        }

        SelectedPlanet.GetComponent<PlanetController>().SizeIndex = index;
        SelectedPlanet.GetComponent<PlanetController>().LerpToSize(_planetScales[index], lerpTime);

        if(!_uiPlanet.activeSelf) return;

        _uiPlanet.GetComponent<UIPlanetController>().LerpToSize(_planetScales[index], index, lerpTime);
    }

    public void SetPlanetMaterial(int index)
    {
        if (index >= _planetMaterials.Count)
        {
            return;
        }
        SelectedPlanet.GetComponent<PlanetController>().MaterialIndex = index;
        SelectedPlanet.GetComponent<MeshRenderer>().material = _planetMaterials[index];
        _uiPlanet.GetComponentInChildren<MeshRenderer>().material = _planetMaterials[index];
    }

    public void AcceptChanges()
    {
        SelectedPlanet.GetComponent<PlanetController>().Init();
    }

    private IEnumerator CountdownTimer()
    {
        m_TimeRemaining = 0;

        while (CurState == SystemState.Revealing)
        {
            yield return new WaitForEndOfFrame();
        }

        while (m_TimeRemaining < ExperienceLength)
        {
            m_TimeRemaining += Time.deltaTime;
            NormalizedTime = m_TimeRemaining / ExperienceLength;
            yield return new WaitForEndOfFrame();
        }

        var _finishedCount = 0;
        var _safetyTimer = 0f;

        CurState = SystemState.Ending;

        while (true)
        {
            foreach (var planet in AllPlanetControllers)
            {
                var _pRot = planet.transform.eulerAngles.y;
                if ((_pRot < 359)) continue;
                planet.GetComponentInParent<PlanetRotation>().BaseRotationSpeed = 0;
                _finishedCount++;
            }

            if (_finishedCount >= AllPlanetControllers.Count)
            {
                break;
            }

            _finishedCount = 0;
            _safetyTimer+=Time.deltaTime;

            //done to stop experience lasting indefinitely if there's an issue
            if (_safetyTimer >= 60f)
            {
                break;
            }
            yield return new WaitForEndOfFrame();
        }

        CurState = SystemState.Ended;

        ScreenFader.Instance.FadeToBlack(2f);
        FaderController.Instance.ChangeSize(new Vector3(200, 200, 200), 0.01f);
        FaderController.Instance.FadeToColor(2.5f, Color.black);
        yield return new WaitForSeconds(2.5f);
        ExperienceApp.End();
    }
}
