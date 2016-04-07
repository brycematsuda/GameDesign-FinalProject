using UnityEngine;
using System.Collections;

public class MudBallsBallController : MonoBehaviour {

	private	 AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Ground") {
        	StartCoroutine(Wait(3));
        } 

        if (coll.gameObject.tag == "Player") {
        	audio.Play();
        }
    }

    IEnumerator Wait(float duration)
    {
        //This is a coroutine
        yield return new WaitForSeconds(duration);   //Wait
        Destroy(this.gameObject);
    }
}
