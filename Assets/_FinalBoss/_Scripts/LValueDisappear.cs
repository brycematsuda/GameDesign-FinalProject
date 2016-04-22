using UnityEngine;
using System.Collections;

public class LValueDisappear : MonoBehaviour {
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
			
		}
	}

	public void destroyByFrame(){
		Invoke ("doDestroy", 0f);
	}

	public void doDestroy(){
		Destroy (gameObject);
	}
		
}
