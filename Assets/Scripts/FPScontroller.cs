using UnityEngine;
using System.Collections;

public class FPScontroller : MonoBehaviour {
	//creating public variables
	public float speed = 2f; //making it public will mean  it can be changed in the engine
	//public float LRspeed =  1f; this could be used for slower left right moveent
	public float sensitivity = 12f;
	public GameObject Eyes; //creates a reference to the first person camera

	//variables you wont need to access within the engine
	float moveFB;
	float moveLR;
	float rotationX;
	float rotationY;
	float vertVelocity;

	//jump variables
	float jumpDist=12f;
	float jumpTime;

	CharacterController player;
	// Use this for initialization


	void Start () {
		player = GetComponent<CharacterController> ();//get component means that you get the components from the character controller in the scene

	}
	
	// Update is called once per frame
	void Update () {
		
		//these are the axis for moving front and back
		//Can specify different speeds here if I wanted
		//for example make moveLR slower than FB
		moveFB = Input.GetAxis ("Vertical") * speed;
		moveLR = Input.GetAxis ("Horizontal") * speed;


		//now I am going to set up mouse movement
		//This should modify the rotation of the object
		rotationX = Input.GetAxis("Mouse X") * sensitivity;
		rotationY = Input.GetAxis("Mouse Y") * sensitivity;

		//you can clamp your mouse looking using this  code
		rotationY = Mathf.Clamp(rotationY,-60f,60f);

		//-------------------------------------------------
		Vector3 movement = new Vector3 (moveLR,vertVelocity,moveFB);
		transform.Rotate (0, rotationX, 0);
		Eyes.transform.Rotate(-rotationY, 0, 0);
		movement = transform.rotation * movement;
		player.Move (movement * Time.deltaTime);


		//code for jumping
		if (player.isGrounded == true) {
			jumpTime = 0;
		}

		if (jumpTime < 2) {
			if (Input.GetButtonDown ("Jump")) {
				vertVelocity += jumpDist;

				jumpTime = jumpTime + 1;
			}
		
		}

	}

	void FixedUpdate(){
		//we want to apply gravity when player jumps
		if (player.isGrounded == false) {
			vertVelocity += Physics.gravity.y * Time.deltaTime;//delta time is the length of time off the ground
		} else {
			vertVelocity = 0f;
		}
	}


}
