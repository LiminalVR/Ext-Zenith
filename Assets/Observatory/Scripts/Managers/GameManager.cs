using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;
using System.Collections;
using System.Collections.Generic;
using Liminal.Core.Fader;
using Liminal.SDK.Core;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    public ValueChanges ValueChangesScript;
    public Self selfScript;

    //public Self self;
    public int planetRotation;

    public List<GameObject> planetPivots;
    public List<GameObject> planetObjects;
    public int[] PlanetSettings;


    public float[] planetSpeed;

    public Planet1 planet1;
    public Planet2 planet2;
    public Planet3 planet3;
    public Planet4 planet4;


    public List<Material> PlanetMaterials;


    public string currentPlanet;


    public GameObject Planet;
    

    public bool ChangeSpeed;
    public bool OnPlanet1 =false;
    public bool OnPlanet2 = false;
    public bool OnPlanet3 = false;
    public bool OnPlanet4 = false;
    [Space]
    public float TimeRemaining;


    public delegate void PlanetSelected();
    public PlanetSelected PlanetWasSelected;

    void Start ()
    {
        Instance = this;
        ChangeSpeed = false;

        StartCoroutine(CountdownTimer());
    }

    public void SelectPlanet(GameObject selectedPlanet)
    {
        ValueChangesScript.planet = selectedPlanet;
        ValueChangesScript.planetPivot = selectedPlanet;

        if (PlanetWasSelected != null)
        {
            PlanetWasSelected.Invoke();
        }
    }

    private IEnumerator CountdownTimer()
    {
        while (TimeRemaining > 0)
        {
            TimeRemaining -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        ScreenFader.Instance.FadeToBlack(2f);
        yield return new WaitForSeconds(2.5f);
        ExperienceApp.End();
    }
}
