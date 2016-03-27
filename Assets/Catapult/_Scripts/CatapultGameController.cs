using UnityEngine;
using System.Collections;

public class CatapultGameController : MonoBehaviour {

	public AudioSource[] soundTrack;
	private AudioSource chosen;
	private bool outOfTime = false;
	public bool gameOver = false;
	// Use this for initialization
	void Start () {
		int songToPlay = Random.Range (0, 3);
		chosen = soundTrack [songToPlay];
		chosen.Play ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!chosen.isPlaying && !outOfTime) {
			outOfTime = true;
			gameOver = true;
			Invoke ("checkForWin", 6f);
		}
	}

	void checkForWin(){
		GameObject winner = GameObject.FindWithTag ("Player");
		if (winner != null) {
			Debug.Log ("WIN");
		} else {
			Debug.Log ("LOSE");
		}
	}
}
