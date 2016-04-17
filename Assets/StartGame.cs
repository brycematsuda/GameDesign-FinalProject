using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour {

	public string sceneName;
	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectWithTag ("Randomizer").GetComponent<Randomizer> ().setFloweys ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			startGame ();
		}
	}

	void startGame(){
		SceneManager.LoadScene (sceneName);
	}
}
