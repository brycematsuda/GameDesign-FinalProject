using UnityEngine;
using System.Collections;

public class RandomlyTurn : MonoBehaviour {
	bool toggl = true;
	public MeshRenderer mr;
	// Use this for initialization
	void Start () {
		Invoke ("doIt", 3f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void doIt(){
		if (!toggl) {
			Invoke ("doIt", Random.Range (2, 4));

		} else {
			
			Invoke ("doIt", Random.Range (5, 9));
		}
		toggl = !toggl;
		gameObject.SetActive (toggl);
		mr.enabled = !toggl;

	}
}
