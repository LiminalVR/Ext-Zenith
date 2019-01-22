using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnPlanetClick : MonoBehaviour {


    

	// Use this for initialization
	void Start () {
		
	}
    public void OnCollisionEnter(Collision collision)
    {
        print("Gotem");
    }


    // Update is called once per frame
    void Update () {

	}
}
