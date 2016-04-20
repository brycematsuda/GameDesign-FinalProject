using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossGameController : MonoBehaviour {
	public int examScore = 0, willpower = 100;
	public Text scoreText, willText, buttText;
	public int min, max;
	public AudioSource hit;
	public GameObject secondGaster, thirdGaster, fourthGaster;
	private GameObject butt, boss;
	private string[] answers;


	// Use this for initialization
	void Start () {
		scoreText.text = "Exam Score: " + examScore;
		willText.text = "Willpower: " + willpower;
		butt = GameObject.FindGameObjectWithTag ("Correct");
		boss = GameObject.FindGameObjectWithTag ("Orange");
		answers = new string[] { "2^n", "NP-COMPLETE", "P = NP", "L-VALUES", "BUBBLE SORT", "SUBSET-SUM", "OVERRIDING", "OVERLOADING", "SWITCH STATEMENT" };
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addScore(int change){
		examScore += change;
		if (examScore > 10) {
			secondGaster.GetComponent<SpawnGaster> ().doIt = true;
		}
		if (examScore > 30) {
			//bfs
		}
		if (examScore > 40) {
			boss.GetComponent<BossController> ().startPatrol ();
		}
		if (examScore > 60) {
			thirdGaster.GetComponent<SpawnGaster> ().doIt = true;
			fourthGaster.GetComponent<SpawnGaster> ().doIt = true;
		}
		float xPos = Random.Range (200, 1400);
		float yPos = Random.Range (100, 450);
		int idx = Random.Range (0, answers.Length-1);
		butt.transform.position = new Vector3 (xPos, yPos);
		buttText.text = answers [idx];
		scoreText.text = "Exam Score: " + examScore;
	}

	public void addWillpower(int change){
		hit.Play ();
		willpower += change;
		willText.text = "Willpower: " + willpower;
	}
}
