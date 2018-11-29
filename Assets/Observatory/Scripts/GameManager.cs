using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class GameManager : MonoBehaviour {

    public GameManager Instance;
    //public Self self;
    public int planetRotation;

    public List<GameObject> planetObjects;
    public int[] PlanetSettings;

    public Planet1 planet1;
    public Planet2 planet2;
    public Planet3 planet3;


    public List<Material> PlanetMaterials;


    public string currentPlanet;
 

   // public GameObject[] planetObjects;

 
	void Start ()
    {
        
        Instance = this;

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
            if (!planetObjects.Contains(planet1.SelfObject))
            {
                planetObjects.Add(planet1.SelfObject);
                PlanetMaterials.Add(planet1.Planet1Material);
            }
            else if (!planetObjects.Contains(planet2.SelfObject))
            {
                planetObjects.Add(planet2.SelfObject);
                PlanetMaterials.Add(planet2.Planet2Material);
            }

            else if (!planetObjects.Contains(planet3.SelfObject))
            {
                planetObjects.Add(planet3.SelfObject);
                PlanetMaterials.Add(planet3.Planet3Material);
            }
            // this handles input

               

        }

    }



    // Update is called once per frame
    void Update () {
      
       
    }
}
