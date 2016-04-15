using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StaticScreenControl : MonoBehaviour {
	public string targetScene = "CatapultScene";
	// Use this for initialization
	void Start () {
		//gameObject.SetActive (true);
		Invoke ("disableFirst", 1.2f);
		Invoke ("enableAfter", 16.4f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void disableFirst(){
		gameObject.SetActive (false);
	}

	void enableAfter(){
		gameObject.SetActive (true);
		Invoke ("startGame", 1f);
	}

	void startGame(){
		SceneManager.LoadScene (targetScene);
	}
}
