using UnityEngine;
using System.Collections;

public class LaunchDebris : MonoBehaviour {

	public GameObject[] debris;
	public float minWait;
	public float maxWait;
	public float spawnRange;
	// Use this for initialization
	void Start () {
		Invoke ("fireRandomDebris", 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void fireRandomDebris(){
		float delay = Random.Range (minWait, maxWait);
		Invoke ("fireRandomDebris", delay);
		int randomDebris = Random.Range (0, debris.Length);
		float randomY = Random.Range (0, spawnRange);
		Instantiate(debris[randomDebris], new Vector3(transform.position.x, transform.position.y + randomY, transform.position.z), transform.rotation);
	}
}
