using System;
using UnityEngine;
using System.Collections;

public class ThrowObject : MonoBehaviour{
  //Player shit
	public Transform player;
	public Transform playerCamera;
	public Transform objectHoldingPoint;
	public GameObject soundWave;
	public PlayerCarryCheck playerCarry;
	public float soundVolume = 1f;

  //Throw force
  public float throwForce = 10;

  //bool for player and object
  bool playerPresent = false;
  bool carried = false;

  //Sound
  public AudioClip[] soundToPlay;
  private AudioSource audioSource;
	private AudioClip clip;

  //Damage
  private int damage;

  //Hit?
  private bool hit = false;


  void Start()
  {
		audioSource = gameObject.GetComponent<AudioSource>();
		playerCarry = player.gameObject.GetComponent<PlayerCarryCheck> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		playerCamera = GameObject.FindGameObjectWithTag ("MainCamera").transform;
		objectHoldingPoint = playerCamera.FindChild ("Object Point").transform;
  }

  void Update()
  {
      float dist = Vector3.Distance(gameObject.transform.position, player.position);
      //Check player
      if (dist <= 2.5f)
      {
        playerPresent = true;

      }
      else
      {
        playerPresent = false;
      }

      //Pick up item
		if (playerPresent && Input.GetKeyDown(KeyCode.E) && playerCarry.isCarrying == false)
      {
			GetComponent<Rigidbody>().useGravity = true;
        //transform.parent = playerCamera;
		playerCarry.isCarrying = true;
        carried = true;
      }

      //Throwing
      if(carried)
      {
			transform.position = Vector3.Lerp(this.transform.position, objectHoldingPoint.position, 0.4f);
			GetComponent<Rigidbody> ().velocity = Vector3.zero;

		
        //If the object is hit, drop it
        if (hit)
        {
        	  GetComponent<Rigidbody>().useGravity = true;
        	  transform.parent = null;
        	  carried = false;
        	  hit = false;
				playerCarry.isCarrying = false;
				//GameObject SoundLight = (GameObject)Instantiate (soundWave, this.transform);
				//SoundLight.transform.parent = null;
				//SoundLight.transform.position = this.transform.position;
        }
        //Throw the fucking thing
        if (Input.GetMouseButtonDown(0))
        {
				GetComponent<Rigidbody>().useGravity = true;
          transform.parent = null;
          carried = false;
          GetComponent<Rigidbody>().AddForce(playerCamera.forward * throwForce);
				//GameObject SoundLight = (GameObject)Instantiate (soundWave, this.transform);
				//SoundLight.transform.parent = null;
				//SoundLight.transform.position = this.transform.position;
				playerCarry.isCarrying = false;
        }
        //Drop that thing
        else if (Input.GetMouseButtonDown(1))
        {
				GetComponent<Rigidbody>().useGravity = true;
          transform.parent = null;
          carried = false;
				playerCarry.isCarrying = false;
				//GameObject SoundLight = (GameObject)Instantiate (soundWave, this.transform);
				//SoundLight.transform.parent = null;
				//SoundLight.transform.position = this.transform.position;
        }
	}
}

//Removed cause of buggy shit regarding floors

void OnTriggerEnter()
    {
		GameObject SoundLight = (GameObject)Instantiate (soundWave, this.transform);
		SoundLight.transform.parent = null;
		SoundLight.transform.position = this.transform.position;

		clip = soundToPlay [UnityEngine.Random.Range(0, soundToPlay.Length)];
			
		AudioSource.PlayClipAtPoint (clip, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), soundVolume);
       /*if (carried)
          {
            hit = true;
          }*/
    }
}
