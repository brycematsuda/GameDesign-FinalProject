using UnityEngine;
using System.Collections;

public class DominoCollider : MonoBehaviour {

	public AudioSource audio;

	// Use this for initialization
	void Start () {
		// audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D coll) {
		Collider2D c = coll.collider;
		if (c.CompareTag("Domino") || c.CompareTag("Player") || c.CompareTag("Finish")) {
			GetComponent<AudioSource>().Play();
		}
	}
}
