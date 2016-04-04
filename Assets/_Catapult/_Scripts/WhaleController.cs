using UnityEngine;
using System.Collections;

public class WhaleController : MonoBehaviour {

	// Use this for initialization
	public float yChange;
	public float speed;
	public float frameSwitch;

	private int count = 0;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (count % frameSwitch == 0) {
			yChange = -yChange;
		}
		count++;
		transform.position = new Vector3 (transform.position.x - speed, transform.position.y + yChange, transform.position.z);
	
	}
}
