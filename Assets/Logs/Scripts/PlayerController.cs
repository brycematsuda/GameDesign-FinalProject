using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	public float speed = 1.0f;
	public float jumpSpeed;
	public bool canMove;

	// Use this for initialization
	void Start () {
		canMove = true;
	}

	// Update is called once per frame
	void Update () {
		
		Rigidbody myBody = GetComponent<Rigidbody> ();
		transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
			
		if (canMove) {
			Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
			transform.position += move * speed * Time.deltaTime;

			if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
				myBody.AddForce(new Vector3(1, 0, 0)  * speed);    
			}
			
			if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
				myBody.AddForce(new Vector3(-1, 0, 0)  * speed);    
			}
			
			if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
				myBody.AddForce(new Vector3(0, 1, 0)  * jumpSpeed);    
			}
		}
	}
}
