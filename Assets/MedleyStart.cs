using UnityEngine;
using System.Collections;

public class MedleyStart : MonoBehaviour {
	Randomizer x;
	// Use this for initialization
	void Start () {
		x = GameObject.FindGameObjectWithTag ("Randomizer").GetComponent<Randomizer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			x.loadNextScene ();
		}
	}
}
