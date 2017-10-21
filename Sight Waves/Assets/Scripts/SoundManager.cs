using System;
using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class SoundManager : MonoBehaviour {

	public GameObject goodSoundWave;
	public GameObject neutralSoundWave;
	public GameObject badSoundWave;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoodSound(Transform location){
		Instantiate (goodSoundWave, location);
	}

	public void NeutralSound(Transform location){
		Instantiate (neutralSoundWave, location);
	}

	public void BadSound(Transform location){
		Instantiate (badSoundWave, location);
	}
}
