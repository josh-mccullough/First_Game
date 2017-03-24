using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterActivate : MonoBehaviour {
    GameObject Blue;
    GameObject Orange;
    GameObject Player;
    bool TeleporterReady = false;
    bool MethodRan = false;


    // Use this for initialization
    void Start () {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        Blue = GameObject.Find("BlueTrigger");
        Orange = GameObject.Find("OrangeTrigger");
        Player = GameObject.Find("Character");
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Blue.GetComponent<BlueActivated>().BlueActivation == true && Orange.GetComponent<OrangeActivated>().OrangeActivation == true && MethodRan == false)
        {
            ActivateTeleporter(); //doing this so that the mesh doesn't render every frame

        }
        else if ((Blue.GetComponent<BlueActivated>().BlueActivation == true || Orange.GetComponent<OrangeActivated>().OrangeActivation == true) )
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
	}

    void ActivateTeleporter()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        TeleporterReady = true;
        //TODO play a sound clip here maybe??
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && TeleporterReady == true)
        {
            Player.GetComponent<Transform>().position = new Vector3(3,66,9 );
            //maybe play a clip here?
        }

    }
}
