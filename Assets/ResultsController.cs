using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ResultsController : MonoBehaviour {
	Randomizer x;
	public Text score, wins, verdict;
	private int wins2;
	// Use this for initialization
	void Start () {
		x = GameObject.FindGameObjectWithTag ("Randomizer").GetComponent<Randomizer> ();
		wins2 = x.getWins ();
		wins.text = "Games won: " + wins2;
		string judge = "";
		Debug.Log (wins2);
		switch (wins2) {
		case 0:
			judge = "AHAHAHAHA YOU SUCK, LOSER";
			break;
		case 1:
			judge = "If only there was nux mode...";
			break;
		case 2:
			judge = "Git gud, son";
			break;
		case 3:
			judge = "50%...just like your grade in algorithms/compilers!";
			break;
		case 4:
			judge = "Ehhhh, not bad.";
			break;
		case 5:
			judge = "Almost there! Stay determined!";
			break;
		case 6:
			judge = "AHAHAHA YOU BEAT THEM ALL?! What a no life loser!";
			break;
		}
		verdict.text = judge;
		int scored = Random.Range (-9000, 9000);
		score.text = "SCORE: " + scored;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
