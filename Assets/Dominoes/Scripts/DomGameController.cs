using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DomGameController : MonoBehaviour {
	public GameObject player;
	public int lives;
	private int score;
	public Text liveGui;
	public Text scoreGui;
	public Text winLoseGui;
	private bool isDisabled;

	// Use this for initialization
	void Start () {
		score = 99999;
		liveGui.text = "Lives: " + lives.ToString();
		scoreGui.text = "Score: " + score.ToString();
		winLoseGui.text = "";
		isDisabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (player.transform.position.y > 0) {
			if (!isDisabled) {
				player.GetComponent<UnityChan2DController>().enabled = false;
				isDisabled = true;
			}			
		} else {
			player.GetComponent<UnityChan2DController>().enabled = true;
			isDisabled = false;
		}

		if (player.transform.position.y < -1.35) {
			if (!isDisabled) {
				player.GetComponent<UnityChan2DController>().enabled = !player.GetComponent<UnityChan2DController>().enabled;
				isDisabled = true;
			}
			
			winLoseGui.text = "Eliminated!";
			StartCoroutine(Wait(3));
		}

		if (player.GetComponent<DomPlayerController>().touchGoal == true) {
			player.GetComponent<DomPlayerController>().canMove = false;
			winLoseGui.text = "Winner!";
			StartCoroutine(Wait(3));			
		}
	}

	IEnumerator Wait(float duration)
    {
        //This is a coroutine
         yield return new WaitForSeconds(duration);   //Wait
			lives -= 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
