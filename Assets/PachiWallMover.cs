using UnityEngine;
using System.Collections;

public class PachiWallMover : MonoBehaviour {

	private int frameSwitch = 15;
	private int rotSpeed;
	private int counter = 0;
	private int counter2 = 0;
	private float direction = 1;
	private float rotDir = 1;
	// Use this for initialization
	void Start () {
		frameSwitch = Random.Range (10, 30);
		if (frameSwitch > 20) {
			rotDir = -1;
		} else {
			rotDir = 1;
		}
		rotSpeed = Random.Range (0, 90);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		counter++;
		counter2++;
		if (counter % frameSwitch == 0) {
			counter = 0;
			direction = -direction;
		}
		float counter3 = counter2 * rotDir;
		transform.position = new Vector3 (transform.position.x + direction/10f, transform.position.y, transform.position.z);
		transform.rotation = Quaternion.Euler (transform.rotation.x, counter3 + rotSpeed, transform.rotation.z);
	}
}
