using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {
	DoorsGameController x;
	// Use this for initialization
	void Start () {
		x = GameObject.FindGameObjectWithTag ("GameController").GetComponent<DoorsGameController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Orange")
        {
            //messageText.text = message;

			x.winner ();
        }
    }
    IEnumerator Waiter()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
    }


}
