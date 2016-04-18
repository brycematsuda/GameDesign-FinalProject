using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Randomizer : MonoBehaviour {

	int[] scenesToPlay = new int[6];//if we add more games, need to change; assumes hubworld is scene 0 in build index, trailerscene is 1
	int currentScene = 0;
	public bool noScenesLeft = false;
	int wins = 0;
	int losses = 0;
	int numPlayed = 0;
	int firstScene = -1;
	int score = 0;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < scenesToPlay.Length; i++) {
			scenesToPlay [i] = i + 2;
		}
		reshuffle (scenesToPlay);

		GameObject.DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene ().name == "HubScene") {
			
			//this is in case you switch back to hubscene in middle of game
		}
	}

	void reshuffle(int[] texts)
	{
		// Knuth shuffle algorithm :: courtesy of Wikipedia :)
		for (int t = 0; t < texts.Length; t++ )
		{
			int tmp = texts[t];
			int r = Random.Range(t, texts.Length);
			texts[t] = texts[r];
			texts[r] = tmp;
		}
	}

	public void loadNextScene(){
		if (currentScene >= scenesToPlay.Length) {
			noScenesLeft = true;
			SceneManager.LoadScene ("ResultsScreen");
			return;
		}
		if (scenesToPlay [currentScene] == firstScene) {
			currentScene++;
			loadNextScene ();
			return;
		}
		SceneManager.LoadScene (scenesToPlay [currentScene]);
		if (firstScene == -1) {
			firstScene = scenesToPlay [currentScene];
		}
		currentScene++;

	}

	public void reset(){
		currentScene = 0;
		noScenesLeft = false;
		reshuffle (scenesToPlay);
		firstScene = -1;
		numPlayed = 0;
	}

	public void addWin(){
		wins++;
	}

	public void addLoss(){
		losses++;
	}

	public int getWins(){
		return wins;
	}

	public int getLosses(){
		return losses;
	}

	public int getScore(){
		return score;
	}

	public void addScore(int toAdd){
		score += toAdd;
	}

	public void setFloweys(){
		numPlayed++;
		GameObject flow1 = GameObject.FindGameObjectWithTag ("Flowey1");
		GameObject flow2 = GameObject.FindGameObjectWithTag ("Flowey2");
		GameObject flow3 = GameObject.FindGameObjectWithTag ("Flowey3");
		GameObject flow4 = GameObject.FindGameObjectWithTag ("Flowey4");
		GameObject flow5 = GameObject.FindGameObjectWithTag ("Flowey5");
		GameObject flow6 = GameObject.FindGameObjectWithTag ("Flowey6");
		GameObject[] flows = {flow1, flow2, flow3, flow4, flow5, flow6 };

		foreach (GameObject x in flows) {
			x.SetActive (false);
		}
		for (int i = 0; i < numPlayed; i++) {
			flows [i].SetActive (true);
		}
		flows [numPlayed-1].GetComponent<AudioSource> ().Play ();
		if (numPlayed == 6) {
			numPlayed = 0;//reset after finished
		}
	}

}
