using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour {
  GameObject Basketball;
  GameObject Canvas;

  void Start () {
    Canvas = GameObject.Find("Canvas");
  }

  void Update () {
    if (Basketball) { //TODO: Fix this garbage
      if (Basketball.transform.position.y + .9f < this.gameObject.transform.position.y) { //TODO: Make .9f dynamic
        Canvas.GetComponent<Gamemaster>().Score++;
        Canvas.GetComponent<Gamemaster>().Generate_Hoop();
        Destroy(this.gameObject);
      }
    }
  }

  void OnCollisionEnter2D (Collision2D collision) {
  	if (collision.gameObject.name == "Basketball") {
      Basketball = collision.gameObject;
      Destroy(this.GetComponent<BoxCollider2D>());
    }
  }
}
