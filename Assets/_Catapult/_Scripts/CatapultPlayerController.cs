﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CatapultPlayerController : MonoBehaviour {
	
	// Time the fire button was held down
	private float holdTime = 0.0f;
	// The speed of the projectile
	public float speed;

	// A reference to the teleportation sphere prefab
	public GameObject shot;
	// A reference to the teleport ball launcher
	public Transform launcher;
	public GameObject barrelReference;
	private GameObject projectile;
	// Reference to the transform where the teleporter projectile
	// will be spawned
	public Transform launcherSpawn;

	public Text statusText;

	//time required between shots
	public float cooldown;

	private CatapultGameController gameController;
	private bool onCooldown = false;
	private bool waiting = false;
	private float countdown = 0;





	// Use this for initialization
	void Start () {
		//launched = false;
		GameObject theObject = GameObject.FindWithTag("GameController");
		if (theObject != null)
		{
			gameController = theObject.GetComponent<CatapultGameController>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameController.gameOver) {
			
			float launchSpeed = holdTime * speed;
			if (countdown == 0) {
				statusText.text = "CATAPULT READY";
				statusText.color = Color.green;
			} else {
				statusText.color = Color.red;
			}
			// Get the mouse position
			Vector2 mousePos = Input.mousePosition;
			// Get the position of the mouse pointer relative to the world
			Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint (mousePos);
			Vector2 mouseDirection = mouseWorldPosition - (Vector2)transform.position;
			if (Input.GetButton ("Fire1") && !onCooldown) {
				holdTime += Time.deltaTime;

				launchSpeed = holdTime * speed;
				if (launchSpeed > 100f) {
					launchSpeed = 100f;
				}
				int readSpeed = (int)launchSpeed;
				statusText.text = "Charging..." + readSpeed + "%";
				if (readSpeed >= 100) {
					launchSpeed = 100f;
					statusText.text = "Charging...MAX";
				}
			}

			if (Input.GetButtonUp ("Fire1")) {
				if (!onCooldown) {
					if (launchSpeed > 100) {
						launchSpeed = 100;
					}
					if (launchSpeed < 50) {
						launchSpeed = 50;
					}
					onCooldown = true;
					countdown = cooldown * 10;
					StartCoroutine (CoolDown ());
					StartCoroutine (Countdown ());
					Transform barrel = GameObject.FindGameObjectWithTag ("Barrel").transform;
					float yRotations =1f;
					float yRotations2 = 90;
					int yRotation = Random.Range(0, 2);
					if (yRotation == 0) {
						yRotations = -1f;
						yRotations2 = 270;
					}
					projectile = (GameObject)Instantiate (shot, launcherSpawn.position, Quaternion.Euler ((yRotations * barrel.eulerAngles.x) + (yRotations * 90), yRotations2, 0));
					Rigidbody[] x = projectile.GetComponentsInChildren<Rigidbody> ();
					for (int i = 0; i < x.Length; i++) {
						x [i].AddForce (new Vector3 (mouseDirection.normalized.x * launchSpeed, mouseDirection.normalized.y * launchSpeed, 0));
					}
					//projectile.GetComponent<Rigidbody> ().AddForce(new Vector3(100, 10, 10));//velocity = new Vector3 (10f, 10f, 10f);//mouseDirection.normalized * ((launchSpeed));

				}
				holdTime = 0.0f;

			}
			if(Input.GetKeyUp (KeyCode.R)) {
				Application.LoadLevel ("CatapultScene");
			}
		} else {
			if(Input.GetKeyUp (KeyCode.R)) {
				Application.LoadLevel ("CatapultScene");
			}
		}
	}

	void FixedUpdate(){
		

	}

	IEnumerator CoolDown(){
		yield return new WaitForSeconds (cooldown);
		onCooldown = false;
		waiting = false;
	}

	IEnumerator Countdown(){
		for (int i = 0; i < cooldown * 10; i++) {
			countdown = countdown - 1f;
			statusText.text = "WAIT: " + countdown;
			yield return new WaitForSeconds (0.1f);
		}
	}
}
