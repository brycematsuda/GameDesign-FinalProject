using UnityEngine;
using System.Collections;

public class MudBallsCannonController : MonoBehaviour {

	public Rigidbody2D bulletPrefab;
	public GameObject fireSpot;

	void Update () {
		if(Input.GetKeyDown (KeyCode.Space)) {
			Fire();
			Debug.Log ("Shoot");
		}
	}

    // Fire a bullet
	void Fire() {
		Rigidbody2D bPrefab = Instantiate(bulletPrefab, fireSpot.transform.position, Quaternion.identity) as Rigidbody2D;
		bPrefab.AddForce (Vector2.up * 1000f);
	}
}
