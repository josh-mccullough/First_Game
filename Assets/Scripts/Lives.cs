using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Lives : MonoBehaviour {
    private int lives = 5;
    public Text livesText;
    public Text GameOver;
    CharacterController CC;
    AudioSource GameOverSound;
    AudioSource Footsteps;
    AudioSource Scream;
    bool MethodRan = false;
    

    // Use this for initialization
    void Start ()
    {
        AudioSource[] CharacterSounds = GetComponents<AudioSource>();
        GameOverSound = CharacterSounds[1];
        Scream = CharacterSounds[2];
        CC = GetComponent<CharacterController>();
        
	}
	
	// Update is called once per frame
	void Update () {

            livesText.text = "Lives: " + lives.ToString();
        if (lives < 1 && MethodRan == false)
        {
            GameOverNow();
        }
	}

    void GameOverNow()
    {
        MethodRan = true;
            GameOverSound.Play();
            livesText.text = "Lives: 0";
            GameOver.text = "Game Over";
            StartCoroutine(WaitAndLoadScene(2.5f)); 
    }



    void OnTriggerEnter(Collider other)
    {
            if (other.tag == "Enemy")
            {
            Scream.Play();
            lives = (lives - 1);
            WaitForPlayerMovement(3);
            CC.transform.position = new Vector3(2,2,-22);
            other.transform.position = new Vector3(-22, 1, -1);
            }
    }

    IEnumerator WaitForPlayerMovement(int wait)
    {
        yield return new WaitForSeconds(wait);
    }

    IEnumerator WaitAndLoadScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }



}
