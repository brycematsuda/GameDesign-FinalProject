using UnityEngine;
using System.Collections;

public class SplashEffect : MonoBehaviour {

	// Use this for initialization
	public GameObject splash;
	RagdollController yes;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			yes = other.GetComponentInParent<RagdollController> ();
			if (yes.didSplash()) {
				return;
			}

			yes.setSplash ();
			yes.playScream ();
			//Instantiate (splash, new Vector3(transform.position.x + 0.25f, transform.position.y, transform.position.z), Quaternion.Euler(90, 90, 0));
		}
	}
}
