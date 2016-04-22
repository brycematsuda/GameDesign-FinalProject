using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevelPlays : MonoBehaviour {
	Randomizer x;
	// Use this for initialization
	void Start () {
		x = GameObject.FindGameObjectWithTag ("Randomizer").GetComponent<Randomizer> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.U)) {
			x.loadNextScene ();
		}
	}

	public void moveToNextScene(bool win){
		if (win) {
			x.addWin ();
		} else {
			x.addLoss ();
		}
		Debug.Log (x.medley);
		x.loadNextScene ();
	}


}
