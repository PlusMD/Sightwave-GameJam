using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoggo : MonoBehaviour {

	public GameObject Doggo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
			Doggo.GetComponent<DoggoController> ().countdown = true;
		}
	}
}
