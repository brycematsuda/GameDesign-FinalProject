using UnityEngine;
using System.Collections;

public class AlgorithmHitController : MonoBehaviour {
	public int damage;
	BossGameController bgc;
	// Use this for initialization
	void Start () {
		bgc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<BossGameController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			bgc.addWillpower (-damage);
		}
	}
}
