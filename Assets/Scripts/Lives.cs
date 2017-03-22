using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour {
    public int lives = 5;
    public Text livesText;
    public Text GameOver;
    public AudioSource EndGame;
    CharacterController CC;
    // Use this for initialization
    void Start () {
        EndGame = GetComponent<AudioSource>();
        CC = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        livesText.text = "Lives: " + lives.ToString();

        if (lives <= 0)
        {
            GameOver.text = "Game Over";
            EndGame.volume = Random.Range(0.8f, 1);
            EndGame.pitch = Random.Range(0.8f, 1.1f);
            EndGame.Play();
            StartCoroutine(WaitAndLoadScene(3));
        }
	}

    void OnCollisionEnter(Collision other)
    {
            if (other.gameObject.tag == "Enemy")
            {
                lives = (lives - 1);
                WaitForPlayerMovement();
                CC.transform.position = new Vector3(0,11,-38);
            }
    }

    IEnumerator WaitForPlayerMovement()
    {
        yield return new WaitForSeconds(4f);
    }


    IEnumerator WaitAndLoadScene(int waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }



}
