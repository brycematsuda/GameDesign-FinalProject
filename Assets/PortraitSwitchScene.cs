using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PortraitSwitchScene : MonoBehaviour {

	public string sceneName; //the scene to switch to
	HubMovie movCube;
	public bool isMedley = false;
	Randomizer x;
	// Use this for initialization
	void Start () {
		movCube = GameObject.FindGameObjectWithTag ("Fire").GetComponent<HubMovie> ();
		x = GameObject.FindGameObjectWithTag ("Randomizer").GetComponent<Randomizer> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			movCube.stopMov ();
			x.medley = false;
			//Debug.Log (x.medley);
			SceneManager.LoadScene (sceneName);
		}
	}
}
