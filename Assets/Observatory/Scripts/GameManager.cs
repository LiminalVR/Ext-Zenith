using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;
using System.Collections;
using System.Collections.Generic;
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







    // public GameObject[] planetObjects;


    void Start ()
    {
        
        Instance = this;
        ChangeSpeed = false;

       // planetObjects = self.planets;
        //1. Player selects a planet on the world
        //2. Get the planet's index. (number)
        //3. Access the list of planets planetObjects[x] , and then access the planet o the specific index  planetObjects[selectedIndex]
        //4. Edit functionality. 



    }

    public void SelectPlanet(GameObject selectedPlanet)
    {
        ValueChangesScript.planet = selectedPlanet;
        ValueChangesScript.planetPivot = selectedPlanet;
        print(ValueChangesScript.planet.name);
        //ValueChangesScript.PlanetSpeed = //planet1.currentSpeed;
    }


    public void Input()
    {
        var vrDevice = VRDevice.Device;
        if (vrDevice == null)
            return;

        var inputDevice = vrDevice.PrimaryInputDevice;
        if (inputDevice == null)
        {
            return;
        }
            

        if (inputDevice.GetButtonDown(VRButton.One))
        {
          

            
            planetObjects.Clear();
            if (planet1.IWasClicked1)
            {
                
                //planetPivots.Add(planet1.SelfObject);
                planetObjects.Add(planet1.SelfObject);
                ValueChangesScript.planet = planetObjects[0];
                ValueChangesScript.planetPivot = planetPivots[0];
                print(ValueChangesScript.planet.name);
                ValueChangesScript.PlanetSpeed = planet1.currentSpeed;
                OnPlanet1 = true;
                OnPlanet3 = false;
                OnPlanet2 = false;
                OnPlanet4 = false;


            }



            else if (planet2.IWasClicked2 == true)
            {
                
                //planetPivots.Add(planet2.SelfObject);
                planetObjects.Add(planet2.SelfObject);
                ValueChangesScript.planet = planetObjects[0];
                ValueChangesScript.planetPivot = planetPivots[1];
                print(ValueChangesScript.planet.name);
                ValueChangesScript.PlanetSpeed = planet2.currentSpeed;
                OnPlanet2 = true;
                OnPlanet3 = false;
                OnPlanet1 = false;
                OnPlanet4 = false;


            }



            else if (planet3.IwasClicked3)
            {
               
                
               // planetPivots.Add(planet3.SelfObject);
                planetObjects.Add(planet3.SelfObject);
                ValueChangesScript.planet = planetObjects[0];
                ValueChangesScript.planetPivot = planetPivots[2];
                print(ValueChangesScript.planet.name);
                ValueChangesScript.PlanetSpeed = planet3.currentSpeed;
                OnPlanet3 = true;
                OnPlanet1 = false;
                OnPlanet2 = false;
                OnPlanet4 = false;
            }
            else if (planet4.IwasClicked4)
            {

                //planetPivots.Add(planet1.SelfObject);
                planetObjects.Add(planet4.SelfObject);
                ValueChangesScript.planet = planetObjects[0];
                ValueChangesScript.planetPivot = planetPivots[3];
                print(ValueChangesScript.planet.name);
                ValueChangesScript.PlanetSpeed = planet4.currentSpeed;
                OnPlanet4 = true;
                OnPlanet3 = false;
                OnPlanet2 = false;
                OnPlanet1 = false;


            }


        }

    }



    // Update is called once per frame
    void Update () {

        Input();
    }
}
