using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySizeSFX : MonoBehaviour {

    public AudioClip Sound;

    public AudioSource Source;

	// Use this for initialization
	void Start ()
    {
        Source.clip = Sound;
	}
	
	// Update is called once per frame
	void PlaySound ()
    {
        Source.Play();
	}
}
