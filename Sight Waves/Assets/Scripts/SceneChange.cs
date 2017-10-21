using System;
using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class SceneChange : MonoBehaviour
{
	public string nextLevel;

	void OnTriggerEnter (Collider other)
  {
    if(other.gameObject.tag == "Player"){
			Application.LoadLevel(nextLevel);
    }
  }
}
