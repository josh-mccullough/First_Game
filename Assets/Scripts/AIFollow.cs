using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollow : MonoBehaviour {
    private GameObject wayPoint;
    private Vector3 wayPointPos;
    private bool isCoolided;
    //This will be the trolls speed. Adjust as necessary.
    private float speed = 2.0f;
    public Transform target;


    void Start()
    {
        //At the start of the game, the troll will find the gameobject called wayPoint.
        wayPoint = GameObject.Find("wayPoint");
    }

    void Update()
    {

        wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
        //Here, the troll will follow the waypoint.
        transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);

        if (target != null)
        {
            transform.LookAt(target);
        }

    }


   
}
