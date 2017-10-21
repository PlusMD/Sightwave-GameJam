using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour {

	public PlayerCarryCheck playerCarry;

	// Use this for initialization
	void Start () {
		playerCarry = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCarryCheck> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Key"){
			GameObject.Destroy (other.gameObject);
			this.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
			this.gameObject.GetComponent<Rigidbody> ().useGravity = true;
			playerCarry.isCarrying = false;
		}
	}
}
