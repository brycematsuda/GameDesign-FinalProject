using UnityEngine;
using System.Collections;

public class MovingObstacleController : MonoBehaviour {

	private int counter = 0;
	private int direction = 1;
	public float speed; // speed that it moves at
	public float interval; //interval at which it turns (in seconds)
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		transform.GetComponent<Rigidbody> ().velocity = new Vector3 (0, speed * direction, 0);
		if (counter % (interval * 60) == 0) {
			counter = 0;
			direction = -direction;
		}

	}
}
