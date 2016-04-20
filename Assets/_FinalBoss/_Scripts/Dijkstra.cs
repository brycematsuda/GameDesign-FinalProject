using UnityEngine;
using System.Collections;

public class Dijkstra : MonoBehaviour {
	public float speed;
	private Transform target;
	private Vector3 target2;
	private bool setTarget = false;
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		target2 = target.position;
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
