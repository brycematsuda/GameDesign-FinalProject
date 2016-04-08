using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CatapultGameController : MonoBehaviour {

	public AudioSource[] soundTrack;//list of background music that can play
	public AudioSource loser;//sound that plays if you're a loser
	public AudioSource[] audiencePain;//list of sounds that can play when player gets hurt
	public GameObject[] audience;//every member in the audience
	public Text scoreText;
	private int score = 0;
	private AudioSource chosen;//the background music that was selected to play
	private bool outOfTime = false;
	private AudienceReactionPoints arp;
	public bool gameOver = false;
	public GameObject winOrLose;//gameobject containing the text that will display whether you're a whiner or a loser

	private Text resultText;
	// Use this for initialization
	void Start () {
		int songToPlay = Random.Range (0, soundTrack.Length);
		chosen = soundTrack [songToPlay];
		chosen.Play ();
		resultText = winOrLose.GetComponent<Text> ();
		arp = GameObject.FindGameObjectWithTag ("PointsText").GetComponent<AudienceReactionPoints> ();
	
	}

	void FixedUpdate () {
		if (!chosen.isPlaying && !outOfTime) {
			outOfTime = true;
			gameOver = true;
			Invoke ("checkForWin", 4f);
		}
	}

	void checkForWin(){
		GameObject winner = GameObject.FindWithTag ("Player");

		if (winner != null) {
			resultText.text = "YOU'RE WINNER!";
			resultText.color = Color.green;
			arp.spawnText ("AT LEAST ONE SURVIVED-ER, I MEAN...F*** IT, THE REST ARE ALL DEAD, +100", 100, null);
		} else {
			resultText.text = "LOSER! YOU'RE A LOSER! ARE YOU FEELIN' SORRY FOR YOURSELF? WELL YOU SHOULD BE!";
			resultText.color = Color.red;
			loser.Play ();
		}
		resultText.gameObject.SetActive (true);
	}

	//make every member of the audience play their excited animation
	//called when the player gets injured
	public void getExcited(){
		foreach (GameObject x in audience){
			QuerySDMecanimController q = x.GetComponent<QuerySDMecanimController> ();
			q.ChangeAnimation (QuerySDMecanimController.QueryChanSDAnimationType.NORMAL_WIN);
		}
	}

	//called when the player gets injured
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
