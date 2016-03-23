using UnityEngine;
using System.Collections;

public class RagdollController : MonoBehaviour {

	public AudioSource[] screams;
	private bool playedSound = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision other){
		if (!playedSound) {
			Debug.Log (screams.Length);
			int screamToPlay = Random.Range (0, screams.Length);
			screams [screamToPlay].Play ();
			playedSound = true;
		}
	}
}
