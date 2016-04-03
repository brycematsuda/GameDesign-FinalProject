using UnityEngine;
using System.Collections;

public class MudBallsCannonController : MonoBehaviour {

	public Rigidbody2D bulletPrefab;
	public GameObject fireSpot;
	public float initSpeed;
	public float angle;

	void Update () {
		Debug.Log(GameObject.FindGameObjectsWithTag("Respawn").Length);
		if(Input.GetKeyDown (KeyCode.L) && GameObject.FindGameObjectsWithTag("Respawn").Length == 2) {
			Fire();
		}
	}

    // Fire a bullet
	void Fire() {
		Vector3 a = Quaternion.Euler(0, 0, angle) * Vector3.right;
		Rigidbody2D shot = Instantiate(bulletPrefab, fireSpot.transform.position, Quaternion.identity) as Rigidbody2D;
		shot.GetComponent<Rigidbody2D>().velocity = a * initSpeed;
		shot.gravityScale = 3.0f;
	}
}
