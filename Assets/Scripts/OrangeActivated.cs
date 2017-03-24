using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeActivated : MonoBehaviour {
    public bool OrangeActivation = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpecialCubes" && other.name == "Orange")
        {
            OrangeActivation = true;
           
        }

    }

    void OnTriggerExit(Collider other)
    {
        OrangeActivation = false;
        

    }
}
