using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class DoggoController : MonoBehaviour {

	Transform player;
	public Animator fadeAnimator;
	public float timer = 60f;
	public bool countdown = false;
	public Text countdownClock;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (player);

		if (countdown == true) {
			timer -= Time.deltaTime;
			countdownClock.text = timer.ToString ("F2");
		}

		if (timer <= 0) {
			countdown = false;
			DoggoDie ();
		}
	}

	void OnTriggerEnter (Collider other){
		if(other.gameObject.tag == "Player"){
			countdown = false;
			fadeAnimator.SetTrigger ("FadeOutGood");
			player.GetComponent<FirstPersonController> ().enabled = false;
			player.GetComponent<CharacterController> ().enabled = false;
			player.FindChild ("FirstPersonCharacter").transform.LookAt (this.transform.FindChild("Doggo Head"));
		}
	}

	void DoggoDie(){
		countdownClock.text = "00.00";
		gameObject.GetComponent<AudioSource> ().Stop ();
		fadeAnimator.SetTrigger ("FadeOutBad");
		player.GetComponent<FirstPersonController> ().enabled = false;
		player.GetComponent<CharacterController> ().enabled = false;
	}
}
