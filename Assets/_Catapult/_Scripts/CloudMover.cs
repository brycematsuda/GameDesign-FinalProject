using UnityEngine;
using System.Collections;

public class CloudMover : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		speed = -0.5f;
		transform.position = new Vector3 (transform.position.x + speed/10, transform.position.y, transform.position.z);
	}
}
