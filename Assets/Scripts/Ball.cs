using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Rigidbody2D body2d;

	// Use this for initialization
	void Start () {
		body2d =  GetComponent<Rigidbody2D> (); 
		Invoke("GoBall", 2);
	}

	// Update is called once per frame
	void Update () {
		float x_v = body2d.velocity.x;
		if (x_v < 18 && x_v > -18 && x_v !=0) {
			if (x_v > 0) {
				body2d.velocity = new Vector2 (25f, body2d.velocity.y);
			} else {
				body2d.velocity = new Vector2 (-25f, body2d.velocity.y);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D colinfo){
		if (colinfo.gameObject.tag == "Player") {
			Rigidbody2D obj = colinfo.gameObject.GetComponent<Rigidbody2D> ();
			float v_y = body2d.velocity.y;
			v_y = v_y / 2f + obj.velocity.y / 3f;
			body2d.velocity = new Vector2 (body2d.velocity.x, v_y);
			GetComponent<AudioSource> ().pitch = Random.Range (.8f, 1.2f);
			GetComponent<AudioSource> ().Play ();
		}
	}

	void ResetBall(){
		body2d.velocity = new Vector2 (0f, 0f);
		body2d.position = new Vector2 (0f, 0f);
		Invoke("GoBall", 1.5f);
	}

	void GoBall(){
		body2d = GetComponent<Rigidbody2D> ();
		float direction = Random.Range(0, 2);
		float v_y = Random.Range (0f, 8f); 
		if (direction == 0) {
			body2d.velocity =  new Vector2(25f, v_y);
		}
		if (direction == 1){
			body2d.velocity = new Vector2(-25f, v_y);	
		}
	}

	IEnumerator SpawnTime(){
		yield return new WaitForSeconds (1);
	}

}