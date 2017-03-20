using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTriggerEnter : MonoBehaviour {

    void EnterTrigger(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("Level 02");
        }
    }

    
}
