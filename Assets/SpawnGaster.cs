using UnityEngine;
using System.Collections;

public class SpawnGaster : MonoBehaviour {

	public bool doIt = false;
	public GameObject gast;
	// Use this for initialization
	void Start () {
		Invoke("doSpawn", Random.Range(1,3f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void doSpawn(){
		Invoke ("doSpawn", Random.Range (3, 6));
		if (doIt) {
			Instantiate (gast, transform.position, transform.rotation);
		}
	}
}
