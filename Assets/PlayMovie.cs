using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayMovie : MonoBehaviour {
	Renderer r;
	MovieTexture movie;
	void Start(){
		r = GetComponent<Renderer>();
		movie = (MovieTexture)r.material.mainTexture;
		//movie.Stop ();
		movie.Play();

	}
	void Update () {
		if (Input.GetButtonDown ("Jump")) {
			movie.Stop ();
			SceneManager.LoadScene ("HubScene");
//			if (movie.isPlaying) {
//				movie.Pause();
//			}
//			else {
//				movie.Play();
//			}
		}
	}
}
