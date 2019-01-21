using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public PlanetController[] otherPlanets;

    public MeshRenderer Planet1Material;

    public PlanetRotation planetrotationScript;
    public float currentSpeed;

    public GameManager gameManager;

    public MeshRenderer selfMesh;

    public AudioSource OnClickedAudio;

// Use this for initialization
    void Start ()
    {

        currentSpeed = planetrotationScript.rotationSpeed;
        selfMesh.material = Planet1Material.material;
        
    }

    public void Clicked()
    {
        OnClickedAudio.Play(0);
    }
    private void Update()
    {
        if (gameManager.ChangeSpeed == true)
        {
            currentSpeed = gameManager.planetSpeed[0];
            planetrotationScript.rotationSpeed = currentSpeed;

        }

        Planet1Material.material = selfMesh.material;



    }
}
