using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class GameManager : MonoBehaviour {

    public GameManager Instance;
    public ValueChanges ValueChangesScript;
    public Self selfScript;

    //public Self self;
    public int planetRotation;

    public List<GameObject> planetObjects;
    public int[] PlanetSettings;

    public Planet1 planet1;
    public Planet2 planet2;
    public Planet3 planet3;


    public List<Material> PlanetMaterials;


    public string currentPlanet;


    public GameObject Planet;

    public bool ChangeSpeed;



   
 

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


    public void Input()
    {
        var vrDevice = VRDevice.Device;
        if (vrDevice == null)
            return;

        var inputDevice = vrDevice.PrimaryInputDevice;
        if (inputDevice == null)
            return;

        if (inputDevice.GetButtonDown(VRButton.One))
        {
            
            planetObjects.Clear();
            if (planet1.IWasClicked1)
            {
                
                planetObjects.Add(planet1.SelfObject);
                ValueChangesScript.planet = planetObjects[0];
                ValueChangesScript.PlanetSpeed = planet1.currentSpeed * ValueChangesScript.speed1;
                ChangeSpeed = true;

                if (ValueChangesScript.changedValue == true)
                {
                    
                    planet1.currentSpeed = planet1.currentSpeed * ValueChangesScript.NewSpeed;
                    ValueChangesScript.changedValue = false;
                }
                

            }



            else if (planet2.IWasClicked2 == true)
            {
                planetObjects.Add(planet2.SelfObject);
                ValueChangesScript.planet = planetObjects[0];
                ValueChangesScript.PlanetSpeed = planet2.currentSpeed;
                ChangeSpeed = true;


                if (ValueChangesScript.changedValue == true)
                {
                    
                    planet2.currentSpeed = planet2.currentSpeed * ValueChangesScript.NewSpeed;
                    ValueChangesScript.changedValue = false;
                }
            }



            else if (planet3.IwasClicked3)
            {
                
                planetObjects.Add(planet3.SelfObject);
                ValueChangesScript.planet = planetObjects[0];
                ValueChangesScript.PlanetSpeed = planet3.currentSpeed;
                ChangeSpeed = true;


                if (ValueChangesScript.changedValue == true)
                {
                    print("Hello");
                    
                    planet3.currentSpeed = planet3.currentSpeed * ValueChangesScript.NewSpeed;
                    
                    ValueChangesScript.changedValue = false;
                }
            }
         
            
        }

    }



    // Update is called once per frame
    void Update () {
        Input();
        print("New Speed" + ChangeSpeed);
       
    }
}
