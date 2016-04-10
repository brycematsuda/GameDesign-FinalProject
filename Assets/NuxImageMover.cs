using UnityEngine;
using System.Collections;

public class NuxImageMover : MonoBehaviour {

	private Vector3 target;
	private int current = 3;
	public Transform top, bottom, left, right;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("changeTarget",5f, 5f);
		target = right.position;
		current = 3;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		transform.position = Vector3.MoveTowards (transform.position, target, 300 * Time.deltaTime);
	}

	void changeTarget(){
		switch (current) {
		case 0:
			current = 1;
			target = left.position;
			break;
		case 1:
			current = 2;
			target = bottom.position;
			break;
		case 2:
			current = 3;
			target = right.position;
			break;
		case 3:
			current = 0;
			target = top.position;
			break;
		}
	}
}
