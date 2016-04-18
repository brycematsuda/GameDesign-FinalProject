using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DestroyOnlyOnChange : MonoBehaviour {
	string currentScene;
	public string tag = "Music";
	GameObject[] musicObject;
	// Use this for initialization
	void Start () {
		currentScene = SceneManager.GetActiveScene ().name;
		DontDestroyOnLoad (gameObject);
		musicObject = GameObject.FindGameObjectsWithTag (tag);
		if (musicObject.Length == 1 ) {
			AudioSource y = GetComponent<AudioSource>();
			if (y != null) {
				y.Play ();
			}
		} else {
			for(int i = 1; i < musicObject.Length; i++){
				Destroy(musicObject[i]);
			}

		}
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene ().name != currentScene) {
			Destroy (gameObject);
		}
	}
}
