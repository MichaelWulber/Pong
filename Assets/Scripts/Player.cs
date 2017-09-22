using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public KeyCode moveUp;
	public KeyCode moveDown;
	public float speed;

	private Rigidbody2D body2D;

	// Use this for initialization
	void Start () {
		speed = 20f;
		body2D = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		float spd;

		if (Input.GetKey (moveUp)) {
			spd = speed;
		} else if (Input.GetKey (moveDown)) {
			spd = -speed;
		} else {
			spd = 0;
		}

		body2D.velocity = new Vector2(0f, spd);
	}
}
