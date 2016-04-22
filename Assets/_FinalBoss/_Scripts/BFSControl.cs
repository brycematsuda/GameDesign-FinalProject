using UnityEngine;
using System.Collections;

public class BFSControl : MonoBehaviour {
	Vector3 target;
	public Transform[] shotSpawns;
	public GameObject shots;
	// Use this for initialization
	void Start () {
		target = new Vector3 (transform.position.x, transform.position.y + 5, 0);
		InvokeRepeating("doSpawn", 2f, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, target, 2 * Time.deltaTime);
	}

	void doSpawn(){
		foreach (Transform x in shotSpawns) {
			Instantiate (shots, x.position, x.rotation);
		}
	}
}
