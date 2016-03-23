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

	// Use this for initialization
	void Start () {
		score = 99999;
		liveGui.text = "Lives: " + lives.ToString();
		scoreGui.text = "Score: " + score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.y < -3.2) {
			player.GetComponent<DomPlayerController>().canMove = false;
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
