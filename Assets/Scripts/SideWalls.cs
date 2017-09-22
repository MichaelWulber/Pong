﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D hitInfo){
		if (hitInfo.name == "Ball") {
			string wallName = transform.name;
			Game_Manager.Score (wallName);
			GetComponent<AudioSource> ().Play ();
			hitInfo.gameObject.SendMessage ("ResetBall");
		}
	}
}
	