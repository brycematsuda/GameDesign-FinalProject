using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudienceReactionPoints : MonoBehaviour {
	public Text textss;
	public GameObject renderCanvas;
	private CatapultGameController cgc;
	// Use this for initialization
	void Start () {
		cgc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<CatapultGameController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void spawnText(string texts, int score){
		textss.text = texts;// (texts);
		Text herp = (Text) Instantiate (textss, new Vector3(300, 395, 0), transform.rotation);
		herp.transform.SetParent (renderCanvas.transform, false);
		cgc.addScore (score);
	}
}
