using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class GameManager : MonoBehaviour {

    public GameManager Instance;
    public Self self;
    public int planetRotation;

    public List<GameObject> planetObjects;
    public int[] PlanetSettings;

  

    public string currentPlanet;
 

    public GameObject Planet;

 
	void Start ()
    {
        
        Instance = this;

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

            //Planet = self.SelfObject;
            
            planetObjects.Add(self.SelfObject);
          
        }

    }

    // Update is called once per frame
    void Update () {

     
    }
}
