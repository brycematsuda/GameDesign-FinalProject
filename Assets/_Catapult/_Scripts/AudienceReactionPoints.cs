using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudienceReactionPoints : MonoBehaviour {
	public Text textss;
	public GameObject renderCanvas;
	private CatapultGameController cgc;
	private PachinkoGameController pgc;
	// Use this for initialization
	void Start () {
		cgc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<CatapultGameController> ();
		if (cgc == null) {
			pgc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<PachinkoGameController> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void spawnText(string texts, int score, Transform location){
		textss.text = texts;// (texts);
		Text herp = (Text)Instantiate (textss, new Vector3 (720, 395, 0), transform.rotation);
		herp.transform.SetParent (renderCanvas.transform, false);
		if (cgc != null) {
			cgc.addScore (score);
		}
		if (pgc != null) {
			pgc.addScore (score);
		}
	}
}
