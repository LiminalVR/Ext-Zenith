using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public float rotationSpeed;
    public float dampening;
    public GameManager gameManager;

    public int planetIndex;

    private GameObject self;

    private void Start()
    {        
       //rotationSpeed = gameManager.planetRotation[planetIndex]
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate((Vector3.up * rotationSpeed) * (Time.deltaTime * dampening), Space.Self);
    }
}

