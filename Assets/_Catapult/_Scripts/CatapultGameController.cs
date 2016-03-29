using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CatapultGameController : MonoBehaviour {

	public AudioSource[] soundTrack;
	public AudioSource loser;
	private AudioSource chosen;
	private bool outOfTime = false;
	public bool gameOver = false;
	public GameObject winOrLose;

	private Text resultText;
	// Use this for initialization
	void Start () {
		int songToPlay = Random.Range (0, soundTrack.Length);
		chosen = soundTrack [songToPlay];
		chosen.Play ();
		resultText = winOrLose.GetComponent<Text> ();
	
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
			resultText.text = "YOU'RE WINNER!";
			resultText.color = Color.green;
		} else {
			resultText.text = "LOSER! YOU'RE A LOSER! DO YOU FEEL SORRY FOR YOURSELF YOU BIG BABY?";
			resultText.color = Color.red;
			loser.Play ();
		}
		resultText.gameObject.SetActive (true);
	}
}
