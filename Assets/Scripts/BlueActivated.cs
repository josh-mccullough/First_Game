using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueActivated : MonoBehaviour {
    public bool BlueActivation = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpecialCubes" && other.name == "Blue")
        {
            BlueActivation = true;
            Debug.Log("Activated");
        }

    }

    void OnTriggerExit(Collider other)
    {
        BlueActivation = false;
        Debug.Log("Deactivated");

    }

}
