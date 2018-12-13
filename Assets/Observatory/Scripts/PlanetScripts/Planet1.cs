using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet1 : MonoBehaviour {

    public Planet1 planet1;
    public Planet2 planet2;
    public Planet3 planet3;
    
    public GameObject SelfObject;
    public MeshRenderer Planet1Material;

    public PlanetRotation planetrotationScript;
    public float currentSpeed;

    public GameManager gameManager;
    
    public MeshRenderer selfMesh;

    public AudioSource OnClickedAudio;
   


    public bool IWasClicked1;
    // Use this for initialization
    void Start () {
        planet1 = this;
        SelfObject = this.gameObject;
        IWasClicked1 = false;
        currentSpeed = planetrotationScript.rotationSpeed;
        selfMesh.material = Planet1Material.material;
        gameManager.planetSpeed[0] = planetrotationScript.rotationSpeed;

    }

    public void Clicked()
    {
        OnClickedAudio.Play(0);
        IWasClicked1 = true;
        planet2.IWasClicked2 = false;
        planet3.IwasClicked3 = false;
        print("1" + IWasClicked1);
    }
    private void Update()
    {
        if (gameManager.ChangeSpeed == true)
        {
            currentSpeed = gameManager.planetSpeed[0];
            planetrotationScript.rotationSpeed = currentSpeed;

        }
        
        Planet1Material.material= selfMesh.material;



    }

}
