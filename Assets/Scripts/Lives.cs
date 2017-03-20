using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour {
    private int lives = 5;
    public Text livesText; 

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        livesText.text = "Lives: " + lives.ToString();
	}
}
