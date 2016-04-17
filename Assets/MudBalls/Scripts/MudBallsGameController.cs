using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MudBallsGameController : MonoBehaviour {
	public GameObject player;
	private bool isDisabled;
  public Text caughtText;
  public GameObject basket;
  public GameObject cannon;

	// Use this for initialization
	void Start () {
		isDisabled = false;
    caughtText.text = "";
	}
	
	// Update is called once per frame
	void Update () {

		if (basket.GetComponent<MudBallsBasketController>().isCaught) {
			caughtText.text = "Caught!";
			player.transform.GetChild(0).GetComponent<UnityChan2DController>().enabled = false;
		} else if (cannon.GetComponent<MudBallsCannonController>().numBalls == 0 && GameObject.FindGameObjectsWithTag("Respawn").Length == 0) {
        caughtText.text = "Geemu Obah :( \n try gain wit R?";
        player.transform.GetChild(0).GetComponent<UnityChan2DController>().enabled = false;

        if (Input.GetKeyDown (KeyCode.R)) {
              SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    } else {
			caughtText.text = "";
		}

		if (player.transform.GetChild(0).position.y > -1.5) {
			if (!isDisabled) {
				player.transform.GetChild(0).GetComponent<UnityChan2DController>().enabled = false;
				isDisabled = true;
			}			
		} else {
			player.transform.GetChild(0).GetComponent<UnityChan2DController>().enabled = true;
			isDisabled = false;
		}
	}
}
