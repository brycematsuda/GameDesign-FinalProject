using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
	private Rigidbody rb;
	PachinkoGameController pgc;
	AudienceReactionPoints arp; 
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.AddForce (0, 0, 40);
		Invoke ("startingForce", 53f);
		pgc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<PachinkoGameController> ();
		arp = GameObject.FindGameObjectWithTag ("PointsText").GetComponent<AudienceReactionPoints> ();
		//transform.rotation = Quaternion.Euler (Random.Range (0, 90),Random.Range (0, 90),Random.Range (0, 90));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		/**
		if (rb.velocity.z < 5) {//make sure ball is always going fast
			rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y, 5);
		}
		*/
		if (transform.position.y < -9) {
			pgc.setWin (false);
			Destroy (gameObject);
		}
	}

	void startingForce(){
		rb.AddForce (0, 0, 43);
	}

	public void skipIntro(){
		CancelInvoke ("startingForce");
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 13);
		rb.AddForce (0, 0, 41);
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Player") {
			Debug.Log ("COLLIDE");
			arp.spawnText ("YOU ACTUALLY SOLVED THE PUZZLE?!: +9000", 9000, transform);
			pgc.setWin (true);
			Destroy (gameObject);
		}
	}
}
