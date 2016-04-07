using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PortraitSwitchScene : MonoBehaviour {

	public string sceneName; //the scene to switch to
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			SceneManager.LoadScene (sceneName);
		}
	}
}
