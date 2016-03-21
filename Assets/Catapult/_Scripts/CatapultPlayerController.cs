using UnityEngine;
using System.Collections;

public class CatapultPlayerController : MonoBehaviour {
	
	// Time the fire button was held down
	private float holdTime = 0.0f;
	// The speed of the projectile
	public float speed;

	// A reference to the teleportation sphere prefab
	public GameObject shot;
	// A reference to the teleport ball launcher
	public Transform launcher;
	private GameObject projectile;
	// Reference to the transform where the teleporter projectile
	// will be spawned
	public Transform launcherSpawn;

	private CatapultGameController gameController;





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
			// Get the mouse position
			Vector2 mousePos = Input.mousePosition;
			// Get the position of the mouse pointer relative to the world
			Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint (mousePos);
			Vector2 mouseDirection = mouseWorldPosition - (Vector2)transform.position;
			if (Input.GetButton ("Fire1")) {
				holdTime += Time.deltaTime;
				launchSpeed = holdTime * speed;
			}

			if (Input.GetButtonUp ("Fire1")) {
				projectile = (GameObject)Instantiate (shot, launcherSpawn.position, Quaternion.identity);
				projectile.GetComponent<Rigidbody2D> ().velocity = mouseDirection.normalized * ((launchSpeed));
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
}
