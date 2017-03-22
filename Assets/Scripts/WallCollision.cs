using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WallCollision : MonoBehaviour {
    public Text GameOver;
   
    void Start()
    {
   
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Platform")
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
       
        yield return new WaitForSeconds(waitTime);
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
}
