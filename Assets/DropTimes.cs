using UnityEngine;
using System.Collections;

public class DropTimes : MonoBehaviour {
	public float lifetime;
	static bool startDropping = false;
	// Use this for initialization
	void Start () {
		startDropping = false;
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
	}
	
	// Update is called once per frame
	void Update () {
		if (startDropping && !IsInvoking("Dropped")) {
			Invoke ("Dropped", lifetime);
		}
	}

	void Dropped(){
		GetComponent<Rigidbody> ().useGravity = true;
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
	}

	public static void startDrop(){
		startDropping = true;
	}
}
