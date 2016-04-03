using UnityEngine;
using System.Collections;

public class MudBallsBallController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Ground") {
        	StartCoroutine(Wait(3));
        }        
    }

    IEnumerator Wait(float duration)
    {
        //This is a coroutine
        yield return new WaitForSeconds(duration);   //Wait
        Destroy(this.gameObject);
    }
}
