using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashWindow : MonoBehaviour {

	public GameObject smashedWindow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Rock"){
			this.gameObject.SetActive (false);
			smashedWindow.SetActive (true);
		}
	}
}
