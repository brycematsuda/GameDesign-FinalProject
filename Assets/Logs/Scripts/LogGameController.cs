﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogGameController : MonoBehaviour {

	public GameObject player;
	public int lives;
	private int score;
	public Text liveGui;
	public Text scoreGui;
	public Text winLoseGui;
	private bool isDisabled;

	// Use this for initialization
	void Start () {
		score = 0;
		liveGui.text = "Lives: " + lives.ToString();
		scoreGui.text = "Score: " + score.ToString();
		winLoseGui.text = "";
		isDisabled = false;
	}

	// Update is called once per frame
	void Update () {
//		if (player.transform.position.y < -1.35) {
//			if (!isDisabled) {
//				player.GetComponent<PlayerController>().enabled = !player.GetComponent<UnityChan2DController>().enabled;
//				isDisabled = true;
//			}
//
//			winLoseGui.text = "Eliminated!";
//			StartCoroutine(Wait(3));
//		}
//
//		if (player.GetComponent<PlayerController>().touchGoal == true) {
//			player.GetComponent<PlayerController>().canMove = false;
//			winLoseGui.text = "Winner!";
//			StartCoroutine(Wait(3));			
//		}
	}

	public void updateGUI() {
		score += (int) Random.Range(-5f, 50f);
		if(score < 0) {
			score = 0;
		}

		liveGui.text = "Lives: " + lives.ToString();
		scoreGui.text = "Score: " + score.ToString();
	}

	IEnumerator Wait(float duration)
	{
		//This is a coroutine
		yield return new WaitForSeconds(duration);   //Wait
		lives -= 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
