using UnityEngine;
using System.Collections;

public class MedleyStart : MonoBehaviour {
	Randomizer x;
	HubMovie movCube;
	// Use this for initialization
	void Start () {
		x = GameObject.FindGameObjectWithTag ("Randomizer").GetComponent<Randomizer> ();
		movCube = GameObject.FindGameObjectWithTag ("Fire").GetComponent<HubMovie> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			movCube.stopMov ();
			x.loadNextScene ();
		}
	}
}
