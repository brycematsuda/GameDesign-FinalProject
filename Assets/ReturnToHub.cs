using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReturnToHub : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Home) || Input.GetKeyDown(KeyCode.H)){
			SceneManager.LoadScene(0);
		}
	}
}
