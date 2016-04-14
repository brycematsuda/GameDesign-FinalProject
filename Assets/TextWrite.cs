using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextWrite : MonoBehaviour {
	int currentPosition = 0;
	float Delay = 0.05f;
	public string Text = "";
	public string[] additionalLines;
	public GameObject herp;// textSound;
	public GameObject texts;
	private AudioSource textSound;
	private bool nextLineReady = false;
	private bool setReady = false;
	private int currentLine = 0;
	private int numLines = 1;
	private PachinkoGameController pgc;
	private BallController bc;
	Text theText;
	// Use this for initialization
	void Start () {
		theText = GetComponent<Text> ();
		textSound = herp.GetComponent<AudioSource> ();
		StartCoroutine (writeText ());
		WriteText ("HEY!");
		pgc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<PachinkoGameController> ();
		bc = GameObject.FindGameObjectWithTag ("Ball").GetComponent<BallController> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (nextLineReady && !IsInvoking("writeNext")) {
			Invoke ("writeNext", 0.75f);
		}

		//skip dialogue button
		if (Input.GetKeyDown (KeyCode.E)) {
			currentLine = additionalLines.Length - 1;
			writeNext ();
			bc.skipIntro ();
			DropTimes.startDrop ();
			if (texts != null) {
				Destroy (texts);
			}
		}
		
	}

	void WriteText(string aText){
		theText.text = "";
		currentPosition = 0;
		Text = aText;
	}

	IEnumerator writeText(){
		while (true) {
			if (currentPosition < Text.Length) {
				CancelInvoke ("writeNext");
				setReady = false;
				nextLineReady = false;
				textSound.Play ();
				if (currentPosition > 15 * numLines && Text [currentPosition] == ' ') {
					numLines++;
					theText.text += "\n";
				}
				theText.text += Text [currentPosition++];

			} else if(!setReady){
				nextLineReady = true;
				setReady = true;
				textSound.Stop ();
				currentLine++;
				if (currentLine >= additionalLines.Length) {
					pgc.playMusic ();
					Destroy (texts);
					Destroy (gameObject);
					DropTimes.startDrop ();
				}
			}

			yield return new WaitForSeconds (Delay);
		}
	}

	void writeNext(){
		if (currentLine < additionalLines.Length) {
			WriteText (additionalLines [currentLine]);
			numLines = 1;
		} else {
			Destroy (texts);
		}

		//textSound.Play ();

	}
}
