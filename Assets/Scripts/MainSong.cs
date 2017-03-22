using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSong : MonoBehaviour {
    AudioSource Main;
    public Text GameOver;
	// Use this for initialization
	void Start () {

        Main = GetComponent<AudioSource>();
        if (GameOver.text == "")
        {
            Main.Play();
            Main.loop = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
       
        if (GameOver.text == "Game Over")
        {
            Main.Stop();
        }
		
	}
}
