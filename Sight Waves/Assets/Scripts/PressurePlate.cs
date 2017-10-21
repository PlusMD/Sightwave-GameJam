using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

	public Transform upPosition;
	public Transform downPosition;
	public bool enableObject = true;
	public bool stayEnabled = false;
	public bool openDoor = false;
	public GameObject objectToActivate;
	public Rigidbody door;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Box") {
			transform.position = Vector3.Lerp(upPosition.position, downPosition.position, 0.8f);

			if (enableObject == false && openDoor == false) {
				objectToActivate.SetActive (false);
			}

			if (enableObject == true && openDoor == false) {
				objectToActivate.SetActive (true);
			}

			if (stayEnabled == true && openDoor == true) {
				door.isKinematic = false;
				door.useGravity = true;
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Box") {
			transform.position = Vector3.Lerp(downPosition.position, upPosition.position, 0.8f);

			if (enableObject == false && stayEnabled == false && openDoor == false) {
				objectToActivate.SetActive (true);
			}

			if (enableObject == true && stayEnabled == false && openDoor == false) {
				objectToActivate.SetActive (false);
			}
		}
	}
}
