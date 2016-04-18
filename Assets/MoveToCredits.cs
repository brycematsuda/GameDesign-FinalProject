using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MoveToCredits : MonoBehaviour {
	public string creditsOrHub;
	// Use this for initialization
	Randomizer x;
	void Start () {
		x = GameObject.FindGameObjectWithTag ("Randomizer").GetComponent<Randomizer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			SceneManager.LoadScene (creditsOrHub);
			x.reset ();
		}
	}
}
