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
    [SerializeField] private List<Vector3> m_PlanetScales;
    [SerializeField] private List<Material> m_PlanetMaterials;
    [SerializeField] private GameObject UICanvas;
    [SerializeField] private GameObject UIPlanet;
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

        UICanvas.SetActive(true);
        UICanvas.GetComponent<InteractableUIController>().Init();
    }

    public void SetPlanetScale(int index, float lerpTime = 1)
    {
        if (index >= m_PlanetScales.Count)
        {
            return;
        }

        SelectedPlanet.GetComponent<PlanetController>().SizeIndex = index;
        SelectedPlanet.GetComponent<PlanetController>().LerpToSize(m_PlanetScales[index], lerpTime);

        if(!UIPlanet.activeSelf) return;

        UIPlanet.GetComponent<UIPlanetController>().LerpToSize(m_PlanetScales[index], index, lerpTime);
    }

    public void SetPlanetMaterial(int index)
    {
        if (index >= m_PlanetMaterials.Count)
        {
            return;
        }
        SelectedPlanet.GetComponent<PlanetController>().MaterialIndex = index;
        SelectedPlanet.GetComponent<MeshRenderer>().material = m_PlanetMaterials[index];
        UIPlanet.GetComponentInChildren<MeshRenderer>().material = m_PlanetMaterials[index];
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

        var finishedCount = 0;
        var safetyTimer = 0f;

        CurState = SystemState.Ending;

        while (true)
        {
            foreach (var planet in AllPlanetControllers)
            {
                var pRot = planet.transform.eulerAngles.y;
                if ((pRot < 359)) continue;
                planet.GetComponentInParent<PlanetRotation>().baseRotationSpeed = 0;
                finishedCount++;
            }

            if (finishedCount >= AllPlanetControllers.Count)
            {
                break;
            }

            finishedCount = 0;
            safetyTimer+=Time.deltaTime;

            //done to stop experience lasting indefinitely if there's an issue
            if (safetyTimer >= 60f)
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
