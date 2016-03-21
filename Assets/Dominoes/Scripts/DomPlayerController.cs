using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DomPlayerController : MonoBehaviour {

	public float speed = 1.0f;
	public Vector2 jumpHeight;
	// Use this for initialization
	void Start () {
	}
	
	
	// Update is called once per frame
	void Update () {

		if (transform.position.y > -3.2) {
			Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
			transform.position += move * speed * Time.deltaTime;
		    if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))  //makes player jump
		    {
		    	GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);    
		    }
		} else {

			StartCoroutine(Wait(3));
		}
	}

	IEnumerator Wait(float duration)
    {
        //This is a coroutine
         yield return new WaitForSeconds(duration);   //Wait
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
 
}
