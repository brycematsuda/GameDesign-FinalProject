using UnityEngine;
using System.Collections;

public class MudBallsCannonController : MonoBehaviour {

	public GameObject bulletPrefab;
	public GameObject fireSpot;
	public float initSpeed;
	public float angle;
	private	 AudioSource audio;

	void Start() {
		audio = GetComponent<AudioSource>();
	}

	void Update () {
		if(Input.GetKeyDown (KeyCode.L) && GameObject.FindGameObjectsWithTag("Respawn").Length == 0) {
			Fire();
		}
	}

    // Fire a bullet
	void Fire() {
		float newAng = angle + Random.Range(-10.0f, 10.0f);
		Vector3 a = Quaternion.Euler(0, 0, newAng) * Vector3.right;
		GameObject shot = (GameObject) Instantiate(bulletPrefab, fireSpot.transform.position, Quaternion.identity);
		shot.GetComponent<Rigidbody2D>().velocity = a * initSpeed;
		shot.GetComponent<Rigidbody2D>().gravityScale = 3.0f;
		audio.Play();
	}
}
