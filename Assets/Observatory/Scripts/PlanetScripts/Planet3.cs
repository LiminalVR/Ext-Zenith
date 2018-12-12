using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet3 : MonoBehaviour {

    public Planet3 planet3;

    public GameObject SelfObject;
    public Material Planet3Material;

    // Use this for initialization
    void Start()
    {
        planet3 = this;
        SelfObject = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
