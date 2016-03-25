using UnityEngine;
using System.Collections;

public class SpawnDebris : MonoBehaviour {

	public GameObject[] debris;
	public int minInterval;
	public int maxInterval;


	// Use this for initialization
	void Start () {
		Invoke ("spawnDebris", 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void spawnDebris(){
		float randomTime = Random.Range (minInterval, maxInterval);
		int randomObject = Random.Range (0, debris.Length);
		Instantiate (debris [randomObject], transform.position, transform.rotation);

		Invoke ("spawnDebris", randomTime);
	}
}
