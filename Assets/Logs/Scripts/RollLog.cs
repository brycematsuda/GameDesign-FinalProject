using UnityEngine;
using System.Collections;

public class RollLog : MonoBehaviour {

	public bool rollBackwards;
	public float spinSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		if (rollBackwards) {
			transform.Rotate (0, -spinSpeed * Time.deltaTime, 0);
		} else {
			transform.Rotate (0, spinSpeed * Time.deltaTime, 0);
		}
	}
}
