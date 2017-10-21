using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadScene : MonoBehaviour {

	public string level;

	// Use this for initialization
	void Start () {
		Application.LoadLevel(level);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
