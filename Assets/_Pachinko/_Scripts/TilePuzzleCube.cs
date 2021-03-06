﻿using UnityEngine;
using System.Collections;

public class TilePuzzleCube : MonoBehaviour {


	public int cubeType;//lmao
	public bool adjacentToYellow = false;//only matters for blue tiles
	public GameObject nuxBlock; //for green tiles
	public AudioSource[] soundFx;
	public float life = 3f;
	private UnityChan2D thePlayer;
	public int numNuxBlocks = 1;
	private AudienceReactionPoints arp;

	private GameObject orange, lemon, firstOne;
	private AudioSource dingSound;

	static float nuxTime = 0;

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
		arp = GameObject.FindGameObjectWithTag ("PointsText").GetComponent<AudienceReactionPoints> ();
		orange = GameObject.FindGameObjectWithTag ("Orange");
		lemon = GameObject.FindGameObjectWithTag ("Lemon");
		firstOne = GameObject.FindGameObjectWithTag ("Waters");
		dingSound = GameObject.FindGameObjectWithTag ("Debris").GetComponent<AudioSource> ();
		//orange.SetActive (false);
		//lemon.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}

	void FixedUpdate(){
		if (cubeType == (int) CubeTypes.Nintendoge) { 
			if (nuxTime <= 0) {
				nuxTime = 0;
				nuxBlock.SetActive (false);
			} else {
				nuxBlock.SetActive (true);
				nuxTime = nuxTime - (0.03f/numNuxBlocks);//fixedupdate is called 30 times per second by default, but each block is calling it lol
			}
		}


	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Player") {
			switch (cubeType) {
			case (int) CubeTypes.Electric://yellow cubes erectrocute you cuz dey asian
				thePlayer.electrocute ();
				soundFx [0].Play ();
				arp.spawnText ("ELECTROCUTED: +15", 15, transform);
				break;
			case (int) CubeTypes.Normal://pink cubes don't do anything
				break;
			case (int) CubeTypes.Wall://red cubes are just walls, and shouldn't allow the player to pass through. but still knocks em the f down optionally
//				thePlayer.knockedTheFOut();
				break;
			case (int) CubeTypes.Whale://Whale tiles spawn a whale that slows the player down
				break;
			case (int) CubeTypes.Orange://Orange tiles change player's flavor to Orange. Piranhas love oranges and will lick you if you try to cross water
				thePlayer.flavor = "Orange";
				arp.spawnText ("DELICIOUS: +5", 5, transform);
				lemon.SetActive (false);
				firstOne.SetActive (false);
				orange.SetActive (true);
				dingSound.Play ();
				break;
			case (int) CubeTypes.Slider://Purple tiles push you forward one and set your flavor to lemon. Piranhas hate lemons and will avoid you at all costs.
				thePlayer.flavor = "Lemon";
				thePlayer.forcePush ();
				arp.spawnText ("SLIPPED: +5", 5, transform);
				orange.SetActive (false);
				firstOne.SetActive (false);
				lemon.SetActive (true);
				dingSound.Play ();
				break;
			case (int) CubeTypes.Water://Water tiles are filled with piranhas. Piranhas love oranges and will eat you if you taste like them.
										//also, electricity conductoos water, so if it is next to a yellow tile, it will send you back one.
										//tasting like lemons does nothing.
				if (adjacentToYellow) {
					thePlayer.electrocute ();
					soundFx [0].Play ();
					arp.spawnText ("ELECTROCUTED: +15", 15, transform);
				} else if (thePlayer.flavor == "Orange") {
					thePlayer.getEaten ();
					arp.spawnText ("YER B8 M8, GOT 8: +8.8/8", 8, transform);
					dingSound.Play ();
				}
				break;
			case (int) CubeTypes.Nintendoge://causes an image of glorious leader Nuxoll-kun to block the scene for three seconds
				nuxTime = nuxTime + life;
				soundFx [0].Play ();
				arp.spawnText ("FAILED NUX'S EXAM: +1", 1, transform);
				if (nuxTime > 10) {
					nuxTime = 10;
				}
				break;
			}

		}
	}
		

}
