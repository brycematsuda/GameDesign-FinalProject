using UnityEngine;
using System.Collections;

public class DelayedStart : MonoBehaviour {
	public float delay;
	Animator x;
	Animation y;
	// Use this for initialization
	void Start () {
		x = GetComponent<Animator> ();
		gameObject.SetActive (false);
		Invoke ("makeActive", delay);

		//Debug.Log (y.name);


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void makeActive(){
		gameObject.SetActive (true);
	}
}
