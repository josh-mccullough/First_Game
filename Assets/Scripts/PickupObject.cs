using UnityEngine;
using System.Collections;

public class PickupObject : MonoBehaviour {
	GameObject MainCamera;
	bool carrying;
	public float distance;
	GameObject carriedObject;
	public float smooth;


	// Use this for initialization
	void Start () {
		MainCamera = GameObject.FindWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		if (carrying) {
			carry (carriedObject);
			checkDrop ();
		} else {
			pickup();
		}
	}

		void carry(GameObject o){
		
		o.transform.position =Vector3.Lerp(o.transform.position, MainCamera.transform.position + MainCamera.transform.forward * distance, Time.deltaTime*smooth);
		//o.transform.position = Quaternion.identity;
		o.GetComponent<Rigidbody>().rotation = Quaternion.identity;
		}
		
		void pickup(){
		if (Input.GetKeyDown (KeyCode.E)) {
			int x = Screen.width / 2;
			int y = Screen.height / 2;

			Ray ray = MainCamera.GetComponent<Camera> ().ScreenPointToRay (new Vector3 (x, y));
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				pickupable p = hit.collider.GetComponent<pickupable> ();
				if (p != null) {
					carrying = true;
					carriedObject = p.gameObject;
					p.GetComponent<Rigidbody>().useGravity = false;
                    p.GetComponent<Rigidbody>().freezeRotation = true;//THIS LINE FIXES WEIRD PHYSICS ON PICKED UP OBJECTS!!!!!!!!!!
				}
			}
		}
	}
		void checkDrop(){
			if (Input.GetKeyDown(KeyCode.E)){
			dropObject ();
			}
		}
	void dropObject(){
		carrying = false;
		carriedObject.GetComponent<Rigidbody>().useGravity = true;
		carriedObject = null;
	}
	
}
