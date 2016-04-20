using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReturnToHub : MonoBehaviour {
	Randomizer x;
	// Use this for initialization
	void Start () {
		x = GameObject.FindGameObjectWithTag ("Randomizer").GetComponent<Randomizer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Home) || Input.GetKeyDown(KeyCode.H)){
			SceneManager.LoadScene(0);
			if (x != null) {
				x.reset ();
			}
		}
		if(Input.GetKeyDown(KeyCode.Equals)){
			SceneManager.LoadScene ("FinalBoss");
		}
	}
}
