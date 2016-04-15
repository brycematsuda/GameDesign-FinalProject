﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PachinkoGameController : MonoBehaviour {

	public AudioSource[] songList;
	public AudioSource introSong;
	private int gameScore = 0;
	public Text scoreText;
	public GameObject results;
	private Text result;
	// Use this for initialization
	void Start () {
		//int songToPlay = Random.Range (0, songList.Length);
		//songList [songToPlay].Play();
		scoreText.text = "SCORE: " + gameScore;
		result = results.GetComponent<Text> ();
		results.SetActive (false);


	}

	// Update is called once per frame
	void Update () {

	}

	public void playMusic(){
		introSong.Stop ();
		songList [0].Play ();
	}

	public void addScore(int score){
		gameScore += score;
		scoreText.text = "SCORE: " + gameScore;
	}

	public void setWin(bool didWin){
		results.SetActive (true);
		if (didWin) {
			result.color = Color.green;
			result.text = "YOU ACTUALLY SOLVED THE TILE PUZZLE?!?!?!?!?!?!?!?!?!?!";
		} else {
			result.color = Color.red;
			result.text = "HAHAHAHA HOW'D YOU LOSE, THIS PUZZLE IS SO EASY";
		}
	}
}
