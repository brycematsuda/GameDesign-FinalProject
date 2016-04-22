using UnityEngine;
using System.Collections;

public class HeartController : MonoBehaviour {
	public float speed;
	private Vector3 mousePosition;
	public float moveSpeed = 0.1f;
	private Vector3 targetPos;
	// Use this for initialization
	void Start () {
		targetPos = transform.position;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

//		Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
		Rigidbody rb = GetComponent<Rigidbody>();
		//rb.velocity = movement * speed;
		//transform.position += (movement/speed);

//		rb.position = new Vector3(
//			Mathf.Clamp(rb.position.x, -9, 9),
//			0.0f,
//			Mathf.Clamp (rb.position.y, -2, 2)
//		);
//		if (transform.position.y >-3) {
//			transform.position = new Vector3 (transform.position.x, -3);
//		}
//		mousePosition = Input.mousePosition;
//		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
//		Debug.Log (mousePosition);
//		mousePosition = new Vector3 (mousePosition.x, mousePosition.y, 0);
//		//Debug.Log (mousePosition);
//		transform.position = Vector3.Lerp (transform.position, mousePosition, moveSpeed);
			float distance = transform.position.z - Camera.main.transform.position.z;
		targetPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
		if (Input.mousePosition.y > 500) {
			targetPos = new Vector3(Input.mousePosition.x, 500, distance);
		}
			
			targetPos = Camera.main.ScreenToWorldPoint(targetPos);

		transform.position = Vector3.Lerp (transform.position, targetPos, speed * Time.deltaTime);
	}
}
