using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinaleSong : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene ().name == "ResultsScreen" || SceneManager.GetActiveScene().name == "HubScene") {
			Destroy (gameObject);
		}
	}
}
