using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorsGameController : MonoBehaviour {
	public static int lives = 3;
	Randomizer x;
	private bool didWin;
	private UnityChanDoors play;
	public Text livesText, gameOverText, winText;
	public GameObject hudOb;
	string currScene;
	GameObject[] controllers, liveText, gameOverTexts, huds;

	// Use this for initialization
	void Start () {
		controllers = GameObject.FindGameObjectsWithTag ("GameController");

		if (controllers.Length > 1 ){
			for(int i = 1; i < controllers.Length; i++){
				Destroy(controllers[i]);
			}
		}
		GameObject rand = GameObject.FindGameObjectWithTag ("Randomizer");
		x = rand.GetComponent<Randomizer> ();
		play = GameObject.FindGameObjectWithTag ("Orange").GetComponent<UnityChanDoors> ();
		//livesText.text = "Lives: " + lives;

		DontDestroyOnLoad (gameObject);
		currScene = SceneManager.GetActiveScene ().name;
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene ().name != currScene) {
			Destroy (gameObject);
		}
	}

	public void loseLife(){
		livesText = GameObject.FindGameObjectWithTag ("Lemon").GetComponent<Text>();
		lives--;
		livesText.text = "Lives: " + lives;
		if (lives == 0) {
			x.addLoss ();
			play.controlsEnabled = false;

			gameOverText.gameObject.SetActive (true);
			gameOverText.text = "YOU'RE A LOSER";
			Invoke ("delayedLoadNext", 3f);
		}
	}

	void delayedLoadNext(){
		x.loadNextScene ();
	}

	public void winner(){
		winText.gameObject.SetActive (true);
		Invoke ("delayedLoadNext", 3f);
	}
}
