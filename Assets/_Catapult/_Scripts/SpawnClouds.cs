using UnityEngine;
using System.Collections;

public class SpawnClouds : MonoBehaviour {

	public float initDelay;
	public float minWait, maxWait, minY, maxY;
	public GameObject[] clouds;
	// Use this for initialization
	void Start () {
		Invoke ("spawnCloud", initDelay);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void spawnCloud(){
		float delay = Random.Range (minWait, maxWait);
		int randCloud = Random.Range (0, clouds.Length);
		float yOffset = Random.Range (minY, maxY);
		Instantiate(clouds[randCloud], new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z), Quaternion.identity);
		Invoke ("spawnCloud", delay);
	}
}
