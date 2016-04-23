using UnityEngine;
using System.Collections;

public class MoveZZ : MonoBehaviour {
	public Vector3[] targets;
	public Transform[] targett;
	public float speed;
	private Vector3 currTarget;
	int count = 0;
	// Use this for initialization
	void Start () {
		StartCoroutine (moveIt ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator moveIt(){
		while (true) {
			currTarget = targett [count % 2].position;
			count++;
			for (int i = 0; i < 200; i++) {
				transform.position = Vector3.MoveTowards (transform.position, currTarget, speed * Time.deltaTime);
				yield return new WaitForSeconds (0.01f);
			}
		}
	}
}
