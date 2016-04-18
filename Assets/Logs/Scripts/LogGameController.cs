using UnityEngine;
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
	private bool hasWon = false;

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
		updateGUI();
		if (player.transform.position.x > 12 && player.transform.position.x < 15) {
			winLoseGui.text = "Winner!";
			hasWon = true;
		}
	}

	public void updateGUI() {
		if (!hasWon) {
			score += (int)Random.Range (-5f, 6f);
		}
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
