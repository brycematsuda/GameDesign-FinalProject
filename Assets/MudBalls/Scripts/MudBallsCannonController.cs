using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MudBallsCannonController : MonoBehaviour {

	public GameObject bulletPrefab;
	public GameObject fireSpot;
	public float initSpeed;
	public float angle;
	public int numBalls;
	private	 AudioSource audio;
	public Text shotText;

	void Start() {
		audio = GetComponent<AudioSource>();
		shotText.text = "Shots Remaining: " + numBalls.ToString();
	}

	void Update () {
		shotText.text = "Shots Remaining: " + numBalls.ToString();

		if(Input.GetKeyDown (KeyCode.L) && GameObject.FindGameObjectsWithTag("Respawn").Length == 0 && numBalls > 0) {
			Fire();
			numBalls = numBalls - 1;
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
