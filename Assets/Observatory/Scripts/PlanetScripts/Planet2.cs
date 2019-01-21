using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet2 : MonoBehaviour {


    public Planet1 planet1;
    public Planet2 planet2;
    public Planet3 planet3;
    public PlanetRotation planetrotationScript;

    public GameManager gameManager;

    public float currentSpeed;

    public GameObject SelfObject;
    public MeshRenderer Planet2Material;

    public bool IWasClicked2;
   
    public MeshRenderer selfMesh;

    public AudioSource OnClickedAudio;

    // Use this for initialization
    void Start()
    {
        planet2 = this;
        SelfObject = this.gameObject;
        IWasClicked2 = false;
        currentSpeed = planetrotationScript.baseRotationSpeed;
        selfMesh.material = Planet2Material.material;
        gameManager.planetSpeed[1] = planetrotationScript.baseRotationSpeed;

    }

    public void clicked()
    {
        OnClickedAudio.Play(0);
        IWasClicked2 = true;
        planet1.IWasClicked1 = false;
        planet3.IwasClicked3 = false;

        GameManager.Instance.SelectPlanet(gameObject);

        print("2" +IWasClicked2);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.ChangeSpeed == true)
        {
            currentSpeed = gameManager.planetSpeed[1];
            planetrotationScript.baseRotationSpeed = currentSpeed;

        }
        Planet2Material.material = selfMesh.material;

    }
}
