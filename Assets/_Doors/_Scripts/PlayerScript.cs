using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private Rigidbody rb;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float runMult;

    private bool speedChanged;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        speedChanged = false;

	}

    //Called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            //create quick way to make movement jump forward, use to simulate "dive" action
            //float moveVertical = Input.GetAxis("Vertical");
            speed = speed * runMult;
            speedChanged = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            speed = speed / runMult;
            speedChanged = false;
        }

            

    }
	
	// FixedUpdate is called once per physics calculation
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

	
	}
}
