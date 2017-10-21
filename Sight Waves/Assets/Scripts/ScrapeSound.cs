using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapeSound : MonoBehaviour {

	float x = 0;
	float z = 0;
	Rigidbody box;
	public GameObject sound;

	// Use this for initialization
	void Start () {
		box = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		//float x = box.velocity.x;
		//float z = box.velocity.z;

		if (box.velocity.x >= 0.001 || box.velocity.x <= -0.001) {
			sound.SetActive (true);
		}

		if (box.velocity.z >= 0.001 || box.velocity.z <= -0.001) {
			sound.SetActive (true);
		}

		else{
			sound.SetActive (false);
		}

		/*if (box.velocity.z < 0.001) {
			sound.SetActive (false);
		}*/
	}
}
