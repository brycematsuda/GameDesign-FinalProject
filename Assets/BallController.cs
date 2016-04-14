using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.AddForce (0, 0, 40);
		Invoke ("startingForce", 53f);
		//transform.rotation = Quaternion.Euler (Random.Range (0, 90),Random.Range (0, 90),Random.Range (0, 90));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		/**
		if (rb.velocity.z < 5) {//make sure ball is always going fast
			rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y, 5);
		}
		*/
	}

	void startingForce(){
		rb.AddForce (0, 0, 41);
	}

	public void skipIntro(){
		CancelInvoke ("startingForce");
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 13);
		rb.AddForce (0, 0, 41);
	}
}
