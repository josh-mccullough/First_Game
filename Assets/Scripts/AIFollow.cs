using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIFollow : MonoBehaviour {  
    public Transform target;


    void Start()
    {   
    }

    void Update()
    {
        transform.GetComponent<NavMeshAgent>().destination = target.position;
        if (target != null)
        {
            transform.LookAt(target);
        }

    }


   
}
