using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CatapultGameController : MonoBehaviour {

	public AudioSource[] soundTrack;
	public AudioSource loser;
	public AudioSource[] audiencePain;
	public GameObject[] audience;
	public Text scoreText;
	private int score = 0;
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
			resultText.text = "LOSER! YOU'RE A LOSER! ARE YOU FEELIN' SORRY FOR YOURSELF? WELL YOU SHOULD BE!";
			resultText.color = Color.red;
			loser.Play ();
		}
		resultText.gameObject.SetActive (true);
	}

	public void getExcited(){
		foreach (GameObject x in audience){
			QuerySDMecanimController q = x.GetComponent<QuerySDMecanimController> ();
			q.ChangeAnimation (QuerySDMecanimController.QueryChanSDAnimationType.NORMAL_WIN);
		}
	}

	public void playCheer(int cheer){
		foreach (AudioSource a in audiencePain) {
			if (a.isPlaying) {
				return;
			}
		}
		audiencePain [cheer].Play ();
		getExcited ();
	}

	public int getAudienceCheerLength(){
		return audiencePain.Length;
	}

	public void addScore(int scoreToAdd){
		score += scoreToAdd;
		scoreText.text = "SCORE: " + score;
	}
}
