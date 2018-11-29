using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet1 : MonoBehaviour {

    public Planet1 planet1;
    
    public GameObject SelfObject;
    public Material Planet1Material;
    // Use this for initialization
    void Start () {
        planet1 = this;
        SelfObject = this.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
