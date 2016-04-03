using UnityEngine;
using System.Collections;

public class MudBallsGameController : MonoBehaviour {
	public GameObject player;
	private bool isDisabled;

	// Use this for initialization
	void Start () {
		isDisabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.y > -1.5) {
			if (!isDisabled) {
				player.GetComponent<UnityChan2DController>().enabled = false;
				isDisabled = true;
			}			
		} else {
			player.GetComponent<UnityChan2DController>().enabled = true;
			isDisabled = false;
		}
	}
}
