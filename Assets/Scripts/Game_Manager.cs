using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour {

	public static int player_1_score = 0;
	public static int player_2_score = 0;
	public GUISkin theSkin;
	public Transform theBall;


	// Use this for initialization
	void Start () {
		theBall = GameObject.FindGameObjectWithTag ("Ball").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void Score (string wallName){
		if (wallName == "rightWall") {
			player_1_score++;
		}
		else if (wallName == "leftWall") {
			player_2_score++;
		}

		Debug.Log("Player 1 Score is: " + player_1_score);
		Debug.Log("Player 2 Score is: " + player_2_score);
	}


	void OnGUI () {
		GUI.skin = theSkin;
		GUI.Label (new Rect (Screen.width / 2 - 150 - 18, 20, 100, 100), "" + player_1_score);
		GUI.Label (new Rect (Screen.width / 2 + 150 - 18, 20, 100, 100), "" + player_2_score);

		if (GUI.Button (new Rect (Screen.width / 2 - 121 / 2, 35, 121, 53), "RESET")) {
			player_1_score = 0;
			player_2_score = 0;

			theBall.gameObject.SendMessage ("ResetBall");
		}
	}


}
