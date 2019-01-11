using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet4 : MonoBehaviour {

    public Planet1 planet1;
    public Planet2 planet2;
    public Planet3 planet3;
    public Planet4 planet4;
    
    public PlanetRotation planetrotationScript;

    public GameObject SelfObject;
    public MeshRenderer Planet4Material;
    public float currentSpeed;


    public MeshRenderer selfMesh;

    public GameManager gameManager;

    public bool IwasClicked4;

    public AudioSource OnClickedAudio;
    // Use this for initialization
    void Start()
    {
        planet4 = this;
        SelfObject = this.gameObject;
        IwasClicked4 = false;
        currentSpeed = planetrotationScript.rotationSpeed;
        selfMesh.material = Planet4Material.material;
        gameManager.planetSpeed[3] = planetrotationScript.rotationSpeed;
    }

    public void clicked()
    {
        OnClickedAudio.Play(0);
        IwasClicked4 = true;
        planet1.IWasClicked1 = false;
        planet2.IWasClicked2 = false;
        planet3.IwasClicked3 = false;
       

    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.ChangeSpeed == true)
        {
            print("hELLO");
            currentSpeed = gameManager.planetSpeed[3];
            planetrotationScript.rotationSpeed = currentSpeed;

        }
        Planet4Material.material = selfMesh.material;
    }
}
