using UnityEngine;
using System.Collections;

public class MudBallsBasketController : MonoBehaviour {
  public bool isCaught;

	// Use this for initialization
	void Start () {
    isCaught = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

  void OnCollisionEnter2D(Collision2D coll) {
    if (coll.gameObject.tag == "Respawn") {
      isCaught = true;
    } else {
      isCaught = false;
    }
  }
}
