using UnityEngine;
using System.Collections;

public class Collisions : MonoBehaviour {

	public GameObject anObject;

	public AudioSource[] screams;

	private Crying crys;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D other){
		crys = other.gameObject.GetComponentInChildren<Crying> ();
		if (crys != null) {
			crys.disableFace ();
			int screamToPlay = Random.Range (0, 4);
			screams [screamToPlay].Play ();
		}
			
	}
}
