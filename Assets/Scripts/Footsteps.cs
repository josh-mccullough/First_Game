﻿using UnityEngine;
using System.Collections;

public class Footsteps : MonoBehaviour {
	CharacterController cc;
	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (cc.isGrounded == true && cc.velocity.magnitude>2f && cc.GetComponent<AudioSource>().isPlaying ==false){
			GetComponent<AudioSource>().volume = Random.Range (0.8f, 1);
			GetComponent<AudioSource>().pitch = Random.Range (0.8f, 1.1f);
			GetComponent<AudioSource>().Play ();
		}
	}
}
