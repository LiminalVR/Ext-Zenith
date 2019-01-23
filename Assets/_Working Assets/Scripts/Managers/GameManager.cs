﻿using Liminal.SDK.VR;
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

    public bool ChangeSpeed;

    [Space]
    public List<PlanetController> AllPlanetControllers;

    [Header("Experience Length Details:")]
    public float ExperienceLength;
    [Range(0,1)]
    public float NormalizedTime;
    private float m_TimeRemaining;
    public SystemState curState;

    [Header("Planet Scale and Material Variables:")]
    [SerializeField] private List<Vector3> m_PlanetScales;
    [SerializeField] private List<Material> m_PlanetMaterials;
    [SerializeField] private GameObject UICanvas;
    public GameObject SelectedPlanet;

    [Header("Managers:")]
    public IntroManager IntroMan;
    public HeartbeatManager HeartMan;

    [System.Serializable]
    public enum SystemState
    {
        Paused,
        Playing,
        Ending,
        Ended,
    };

    public delegate void PlanetSelected();
    public PlanetSelected PlanetWasSelected;

    void Start ()
    {
        Instance = this;
        ChangeSpeed = false;

        AllPlanetControllers = FindObjectsOfType<PlanetController>().ToList();

        IntroMan = GetComponent<IntroManager>();
        HeartMan = GetComponent<HeartbeatManager>();

        IntroMan.Init();

        curState = SystemState.Playing;

        StartCoroutine(CountdownTimer());
    }

    public void SelectPlanet(GameObject selectedPlanet)
    {
        SelectedPlanet = selectedPlanet;

        if (PlanetWasSelected != null)
        {
            PlanetWasSelected.Invoke();
        }

        UICanvas.SetActive(true);
    }

    public void SetPlanetScale(int index)
    {
        if (index >= m_PlanetScales.Count)
        {
            return;
        }

        SelectedPlanet.transform.localScale = m_PlanetScales[index];
    }

    public void SetPlanetMaterial(int index)
    {
        if (index >= m_PlanetMaterials.Count)
        {
            return;
        }

        SelectedPlanet.GetComponent<MeshRenderer>().material = m_PlanetMaterials[index];
    }

    public void AcceptChanges()
    {
        UICanvas.SetActive(false);

        SelectedPlanet.GetComponent<PlanetController>().PlanetDataSet();
    }

    private IEnumerator CountdownTimer()
    {
        m_TimeRemaining = 0;

        while (m_TimeRemaining < ExperienceLength)
        {
            m_TimeRemaining += Time.deltaTime;
            NormalizedTime = m_TimeRemaining / ExperienceLength;
            yield return new WaitForEndOfFrame();
        }

        var finishedCount = 0;
        var safetyTimer = 0f;

        curState = SystemState.Ending;

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

        curState = SystemState.Ended;

        ScreenFader.Instance.FadeToBlack(2f);
        FaderController.Instance.FadeToColor(2.5f, Color.black);
        yield return new WaitForSeconds(2.5f);
        ExperienceApp.End();
    }
}
