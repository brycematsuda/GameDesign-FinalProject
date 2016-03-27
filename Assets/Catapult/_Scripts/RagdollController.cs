using UnityEngine;
using System.Collections;

public class RagdollController : MonoBehaviour {

	public AudioSource[] screams;
	public GameObject splash;
	private bool playedSound1 = false;
	private bool playedSound2 = false;
	private bool splashed = false;
	private bool isDestroying = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (transform.position.y < -30 && !isDestroying) {
			isDestroying = true;
			Invoke ("startDestroy", 2f);
		}

		if (transform.position.y > 100 && !isDestroying) {
			isDestroying = true;
			Invoke ("startDestroy", 2f);
		}

		if (transform.position.x > 30 && !isDestroying) {
			isDestroying = true;
			Invoke ("startDestroy", 2f);
		}
	}

	void OnCollisionEnter (Collision other){
		if (!playedSound1) {
			int screamToPlay = Random.Range (0, screams.Length);
			screams [screamToPlay].Play ();
			playedSound1 = true;
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Waters") {
			Instantiate (splash, transform.position, Quaternion.identity);
		}
	}

	public bool didSplash(){
		return splashed;
	}

	public void setSplash(){
		splashed = true;
	}

	public void playScream(){
		if (!playedSound2) {
			playedSound2 = true;
			int screamToPlay = Random.Range (0, screams.Length);
			screams [screamToPlay].Play ();
			playedSound2 = true;
		}
	}

	void startDestroy(){
		Destroy (gameObject);
	}
}
