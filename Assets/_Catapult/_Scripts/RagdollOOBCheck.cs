using UnityEngine;
using System.Collections;

public class RagdollOOBCheck : MonoBehaviour {
	private bool isDestroying = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (transform.position);
		if (transform.position.y < -10 && !isDestroying) {
			isDestroying = true;
			Invoke ("startDestroy", 0.5f);
		}

		if (transform.position.y > 100 && !isDestroying) {
			isDestroying = true;
			Invoke ("startDestroy", 0.5f);
		}

		if (transform.position.x > 30 && !isDestroying) {
			isDestroying = true;
			Invoke ("startDestroy", 0.5f);
		}
	}
	void startDestroy(){
		Destroy (transform.parent.transform.parent.gameObject);
	}
}
