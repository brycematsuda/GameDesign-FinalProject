using UnityEngine;
using System.Collections;

public class DomPlayerController : MonoBehaviour {

	public float speed = 1.0f;
	public Vector2 jumpHeight;
	public bool canMove;
	public bool touchGoal = false;

	// Use this for initialization
	void Start () {
		canMove = true;
		touchGoal = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (canMove) {
			Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
			transform.position += move * speed * Time.deltaTime;
		    if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))  //makes player jump
		    {
		    	GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);    
		    }
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Goal") {
        	touchGoal = true;
        } else {
        	touchGoal = false;
        }
    }
}
