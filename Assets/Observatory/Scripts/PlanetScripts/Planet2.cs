using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet2 : MonoBehaviour {

    public Planet2 planet2;

    public GameObject SelfObject;
    public Material Planet2Material;
    // Use this for initialization
    void Start()
    {
        planet2 = this;
        SelfObject = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
