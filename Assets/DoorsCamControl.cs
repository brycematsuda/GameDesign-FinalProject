using UnityEngine;
using System.Collections;

public class DoorsCamControl : MonoBehaviour {

	Vector3[] positions;
	private int currIdx = 0;
	private bool moveToTarget = false;
	// Use this for initialization
	void Start () {
		Vector3 pos1 = transform.position;
		Vector3 pos2 = new Vector3 (1.82f, 11.1f, -57.9f);
		Vector3 pos3 = new Vector3 (1.82f, 11.1f, 0.4f);
		Vector3 pos4 = new Vector3 (1.82f, 11.1f, 64.4f);
		positions = new Vector3[4];
		positions [0] = pos1;
		positions [1] = pos2;
		positions [2] = pos3;
		positions [3] = pos4;
	}
	
	// Update is called once per frame
	void Update () {
		if (moveToTarget) {
			transform.position = Vector3.MoveTowards (transform.position, positions [currIdx], 25 * Time.deltaTime);
		}
		if (transform.position == positions [currIdx]) {
			moveToTarget = false;
		}
	}

	public void moveToNext(){
		currIdx++;
		//transform.position = positions [currIdx];
		moveToTarget = true;
	}

	public void reset(){
		currIdx = 0;
		//transform.position = positions [currIdx];
		moveToTarget = true;
	}
}
