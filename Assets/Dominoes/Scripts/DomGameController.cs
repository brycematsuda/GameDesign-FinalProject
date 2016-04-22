using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DomGameController : MonoBehaviour {
	public GameObject player;
	static int lives = 4;
	private int score;
	// public Text liveGui;
	public Text scoreGui;
	public Text winLoseGui;
	public Text nuxText;
	public bool nuxMode;
	private bool isDisabled;
	private AudioSource audio;
	private float actionCooldown = 2.0f;
	private float timeSinceAction = 0.0f;
 	private bool updateScore;
 	private LayerMask orig;

	Randomizer x;

	// Use this for initialization
	void Start () {
		orig = player.GetComponent<UnityChan2DController>().whatIsGround;
		nuxMode = false;
		nuxText.enabled = false;
		updateScore = true;
		score = Random.Range(0, 99999);
		// liveGui.text = "Lives: " + lives.ToString();
		scoreGui.text = "Score: " + score.ToString();
		winLoseGui.text = "";
		isDisabled = false;
		x = GameObject.FindGameObjectWithTag ("Randomizer").GetComponent<Randomizer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.N)) {
			nuxMode = !nuxMode;
		}

		if (!nuxMode) {
			player.GetComponent<UnityChan2DController>().whatIsGround = orig;
			nuxText.enabled = false;
		} else {
			player.GetComponent<UnityChan2DController>().whatIsGround = LayerMask.NameToLayer("Everything");
			nuxText.enabled = true;
		}
	    timeSinceAction += Time.deltaTime;
	    
	    if (timeSinceAction > actionCooldown && !nuxMode)
		{
		    //timeSinceAction = 0;
		    
		
		if (player.transform.position.y > 0 && !nuxMode) {
			if (!isDisabled) {
				player.GetComponent<UnityChan2DController>().enabled = false;
				isDisabled = true;
			}			
		} else {
			player.GetComponent<UnityChan2DController>().enabled = true;
      if (updateScore) {
      	score = Random.Range(0, 99999);
      	} else {
      		score = score;
      	}
      scoreGui.text = "Score: " + score.ToString();
			isDisabled = false;
		  timeSinceAction = 0;
		}
		}
		if (player.transform.position.y < -1.35) {
			if (!isDisabled) {
				player.GetComponent<UnityChan2DController>().enabled = !player.GetComponent<UnityChan2DController>().enabled;
				isDisabled = true;
				lives--;
				if (lives <= 0) {
					x.addLoss ();
					if (!IsInvoking ("delayedLoad")) {
						Invoke ("delayedLoad", 3f);
					}

				}
			}
			
			winLoseGui.text = "Eliminated!";
			score = -score;
			updateScore = false;
			StartCoroutine(Wait(3));
		}

		if (player.GetComponent<DomPlayerController>().touchGoal == true) {
			player.GetComponent<UnityChan2DController>().enabled = false;
			player.GetComponent<DomPlayerController>().canMove = false;
			winLoseGui.text = "Winner!";
			x.addWin ();
			if (!IsInvoking ("delayedLoad")) {
				Invoke ("delayedLoad", 3f);
			}
			updateScore = false;
			//StartCoroutine(Wait(3));			
		}
	}

	IEnumerator Wait(float duration)
    {
        //This is a coroutine
         yield return new WaitForSeconds(duration);   //Wait

		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

	void delayedLoad(){
		x.loadNextScene ();
	}
}
