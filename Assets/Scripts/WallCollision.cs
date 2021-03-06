﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WallCollision : MonoBehaviour {
    public Text GameOver;
    public Vector3 movementDirection;
    public float Speed;
    bool GameOverChecker = false;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(movementDirection * Speed * Time.deltaTime);

    }
    void Start()
    {
   
    }
    void OnTriggerEnter(Collider other)
    {
       
        if ((other.name == "Character" || other.tag == "Platform")  && GameOverChecker == false)
        {
           
            GameOver.text = "Game Over";
            
            GetComponent<AudioSource>().volume = Random.Range(0.8f, 1);
            GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.1f);
            GetComponent<AudioSource>().Play();
            
            StartCoroutine( WaitAndLoadScene(3));
         
        }
        
    }
        IEnumerator WaitAndLoadScene(int waitTime)
     {
        GameOverChecker = true;
        yield return new WaitForSeconds(waitTime);
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
}
