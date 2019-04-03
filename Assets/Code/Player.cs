using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public GameObject Canvas;
	int Direction = 1;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		this.transform.rotation = Quaternion.Euler(0,0,0);
		if (Canvas.GetComponent<Gamemaster>().Game_State == "Game") {
			if (this.transform.position.x <= -2.6f || this.transform.position.x >= 2.6f) { //TODO: Scale with screen
				Direction *= -1;
			}
			this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x + (.025f * Direction), this.gameObject.transform.position.y);
			if (this.gameObject.transform.position.y >= 5.5 || this.gameObject.transform.position.y <= -5.5) {
				Canvas.GetComponent<Gamemaster>().Game_State = "End";
			}
		}

		if (Input.GetMouseButtonDown(0)) {
			this.gameObject.GetComponent<Rigidbody2D>().AddForce(3f * new Vector2(0, 2f), ForceMode2D.Impulse); //TODO: Fix this trash
		}
	}
}
