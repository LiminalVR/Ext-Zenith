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
    [SerializeField] private List<GameObject> _uiCanvasList;
    [SerializeField] private List<UIPlanetController> _uiPlanets;
    public GameObject SelectedPlanet;

    [Header("Misc")]
    [SerializeField] private MusicController _musicController;

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

    private List<InteractableUIController> m_uiCanvasControllerList;

    void OnEnable ()
    {
        Instance = this;

        IntroMan = GetComponent<IntroManager>();
        HeartMan = GetComponent<HeartbeatManager>();

        IntroMan.Init();
        m_uiCanvasControllerList = new List<InteractableUIController>();

        foreach (var item in _uiCanvasList)
        {
            m_uiCanvasControllerList.Add(item.GetComponent<InteractableUIController>());
        }

        //m_uiCanvasController = _uiCanvas.GetComponent<InteractableUIController>();

        CurState = SystemState.Revealing;

        StartCoroutine(CountdownTimer());
    }

    public void SelectPlanet(GameObject selectedPlanet)
    {
        SelectedPlanet = selectedPlanet;
        foreach (var item in m_uiCanvasControllerList)
        {
            item.gameObject.SetActive(true);
        }

        foreach (var item in m_uiCanvasControllerList)
        {
            item.Init();
            item.ShowHide(true);
        }
    }

    public void UpdateAllCanvasValues()
    {
        foreach (var item in m_uiCanvasControllerList)
        {
            item.Init();
        }
    }

    public void SetPlanetScale(int index, float lerpTime = 1, GameObject targetPlanet = null)
    {
        if (index >= _planetScales.Count)
        {
            return;
        }

        if (targetPlanet == null)
        {
            targetPlanet = SelectedPlanet;
        }

        targetPlanet.GetComponent<PlanetController>().SizeIndex = index;
        targetPlanet.GetComponent<PlanetController>().LerpToSize(_planetScales[index], lerpTime);

        foreach (var item in _uiPlanets)
        {
            if (!item.gameObject.activeSelf) continue;
            if (targetPlanet != SelectedPlanet) return;
            
            item.LerpToSize(_planetScales[index], index, lerpTime);
        }
    }

    public void SetPlanetMaterial(int index, GameObject planet = null)
    {
        var target = planet;

        if (index >= _planetMaterials.Count)
        {
            return;
        }

        if (target == null)
        {
            target = SelectedPlanet;
        }

        target.GetComponent<PlanetController>().MaterialIndex = index;
        target.GetComponent<MeshRenderer>().material = _planetMaterials[index];

        foreach (var item in _uiPlanets)
        {
            item.GetComponentInChildren<MeshRenderer>().material = _planetMaterials[index];
        }
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

       

        _musicController.End(5f);

        FaderController.Instance.ChangeSize(new Vector3(200, 200, 200), 0.01f);
        FaderController.Instance.FadeToColor(5f, Color.black);
        yield return new WaitForSeconds(5f);

        ScreenFader.Instance.FadeToBlack(2f);
        yield return new WaitForSeconds(2f);

        ExperienceApp.End();
    }
}
