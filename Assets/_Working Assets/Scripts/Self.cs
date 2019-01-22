using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Self : MonoBehaviour {

    // Use this for initialization
    public Self self;
    public GameObject SelfObject;
   // public List<GameObject> planets;
    public GameManager GameManager;
    //public GameObject[] planets;
   
  


    void Awake () {

        self = this;
        SelfObject = this.gameObject;

        
     
    }
	
    public void OnClicked()
    {
        print(this.gameObject.name);
    }
    
	// Update is called once per frame
	void Update () {
     
    }
}
