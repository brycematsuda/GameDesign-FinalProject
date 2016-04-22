using UnityEngine;
using System.Collections;

public class BreadthFirst : MonoBehaviour {
	public bool doIt = false;
	public GameObject bfs;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void doSpawn(){
		Invoke ("doSpawn", Random.Range (3, 6));
		if (doIt) {
			transform.position = new Vector3 (Random.Range (-6, 6), transform.position.y, transform.position.z);
			Instantiate (bfs, transform.position, transform.rotation);
		}
	}

	public void startSpawning(){
		Invoke("doSpawn", Random.Range(1,3f));
	}
}
