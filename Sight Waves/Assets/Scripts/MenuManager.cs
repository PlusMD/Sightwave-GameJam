using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MenuManager : MonoBehaviour {

	public GameObject player;
	public GameObject cursor;
	public Animator mainMenuAnimator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D)) {
			player.GetComponent<FirstPersonController> ().enabled = true;
			player.GetComponent<CharacterController> ().enabled = true;
			mainMenuAnimator.SetTrigger ("FadeOut");
			cursor.SetActive (true);
		}
	}
}
