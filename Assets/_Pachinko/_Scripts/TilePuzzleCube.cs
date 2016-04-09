using UnityEngine;
using System.Collections;

public class TilePuzzleCube : MonoBehaviour {


	public int cubeType;//lmao
	public bool adjacentToYellow = false;//only matters for blue tiles
	public GameObject nuxBlock; //for green tiles
	public AudioSource[] soundFx;
	private UnityChan2D thePlayer;

	// Use this for initialization


	private enum CubeTypes{
		Electric = 0,
		Normal = 1,
		Wall = 2,
		Whale = 3,
		Orange = 4,
		Slider = 5,
		Water = 6,
		Nintendoge = 7
	}
	void Start () {
		thePlayer = GameObject.FindGameObjectWithTag ("Player").GetComponent<UnityChan2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Player") {
			switch (cubeType) {
			case (int) CubeTypes.Electric://yellow cubes erectrocute you cuz dey asian
				thePlayer.electrocute ();
				soundFx [0].Play ();
				break;
			case (int) CubeTypes.Normal://pink cubes don't do anything
				break;
			case (int) CubeTypes.Wall://red cubes are just walls, and shouldn't allow the player to pass throug
				break;
			case (int) CubeTypes.Whale://Green tiles spawn a whale that slows the player down
				break;
			case (int) CubeTypes.Orange://Orange tiles change player's flavor to Orange. Piranhas love oranges and will lick you if you try to cross water
				thePlayer.flavor = "Orange";
				Debug.Log (thePlayer.flavor);
				break;
			case (int) CubeTypes.Slider://Purple tiles push you forward one and set your flavor to lemon. Piranhas hate lemons and will avoid you at all costs.
				thePlayer.flavor = "Lemon";
				thePlayer.forcePush ();
				break;
			case (int) CubeTypes.Water://Water tiles are filled with piranhas. Piranhas love oranges and will eat you if you taste like them.
										//also, electricity conductoos water, so if it is next to a yellow tile, it will send you back one.
										//tasting like lemons does nothing.
				if (adjacentToYellow) {
					thePlayer.electrocute ();
					soundFx [0].Play ();
				} else if (thePlayer.flavor == "Orange") {
					thePlayer.getEaten ();
				}
				break;
			case (int) CubeTypes.Nintendoge://causes an image of glorious leader Nuxoll-kun to block the scene
				nuxBlock.SetActive (true);
				if (IsInvoking ("disableImage")) { 
					CancelInvoke ("disableImage");
					Invoke ("disableImage", 3f);
				} else {
					Invoke ("disableImage", 3f);
				}

				break;
			}

		}
	}

	void disableImage(){
		nuxBlock.SetActive(false);
	}

}
