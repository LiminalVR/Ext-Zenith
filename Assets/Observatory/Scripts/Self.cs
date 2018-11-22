using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Self : MonoBehaviour {

    // Use this for initialization
    public Self self;
    public GameObject SelfObject;

   
	void Awake () {

        self = this;
        SelfObject = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        print(SelfObject.name);

    }
}
