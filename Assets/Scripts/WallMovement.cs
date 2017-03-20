using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour {
    public Vector3 movementDirection;
    public float Speed;
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(movementDirection * Speed * Time.deltaTime);

    }
}
