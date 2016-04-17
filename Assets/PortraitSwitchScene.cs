using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PortraitSwitchScene : MonoBehaviour {

	public string sceneName; //the scene to switch to
	HubMovie movCube;
	// Use this for initialization
	void Start () {
		movCube = GameObject.FindGameObjectWithTag ("Fire").GetComponent<HubMovie> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			movCube.stopMov ();
			SceneManager.LoadScene (sceneName);
		}
	}
}
