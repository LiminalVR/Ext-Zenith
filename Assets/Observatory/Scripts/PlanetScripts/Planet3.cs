using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet3 : MonoBehaviour {


    public Planet1 planet1;
    public Planet2 planet2;
    public Planet3 planet3;
    public PlanetRotation planetrotationScript;

    public GameObject SelfObject;
    public MeshRenderer Planet3Material;
    public float currentSpeed;

 
    public MeshRenderer selfMesh;

    public GameManager gameManager;

    public bool IwasClicked3;

    public AudioSource OnClickedAudio;
    // Use this for initialization
    void Start()
    {
        planet3 = this;
        SelfObject = this.gameObject;
        IwasClicked3 = false;
        currentSpeed = planetrotationScript.baseRotationSpeed;
        selfMesh.material = Planet3Material.material;
        gameManager.planetSpeed[2] = planetrotationScript.baseRotationSpeed;
    }

    public void clicked()
    {
        OnClickedAudio.Play(0);
        IwasClicked3 = true;
        planet1.IWasClicked1 = false;
        planet2.IWasClicked2 = false;
        print("3" + IwasClicked3);

        GameManager.Instance.SelectPlanet(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.ChangeSpeed == true)
        {
            currentSpeed = gameManager.planetSpeed[2];
            planetrotationScript.baseRotationSpeed = currentSpeed;
            
        }
        Planet3Material.material = selfMesh.material;
    }
}
