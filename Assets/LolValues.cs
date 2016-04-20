using UnityEngine;
using System.Collections;

public class LolValues : MonoBehaviour {
	public GameObject blast;
	public GameObject fireSprite;
	public GameObject idleSprite;
	public GameObject shotSpawn;
	private Transform player;
	Vector3 target;
	// Use this for initialization
	void Start () {
		StartCoroutine (blastRandom());
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator blastRandom(){
		while (true) {
			
			yield return new WaitForSeconds (Random.Range (3f, 4f));
			//play charge audio
			GetComponent<AudioSource> ().Play ();

			Invoke ("fireLazer", 1f);

			float targetY = Random.Range (-5, 5);
			for (int i = 0; i < 100; i++) {
				target = player.transform.position;
				//Debug.Log (target);
				target.y = 0;
				target.z = 0;
				Quaternion targets = Quaternion.LookRotation (target - transform.position);
				Debug.Log (targets);
				transform.rotation = Quaternion.Slerp (transform.rotation, targets, 20 * Time.deltaTime);
				transform.position = Vector3.MoveTowards (transform.position, new Vector3 (transform.position.x, targetY, transform.position.z), 30 * Time.deltaTime);
				yield return new WaitForSeconds (0.01f);
			}
			//transform.LookAt (target);

		}
	}

	void fireLazer(){
		fireSprite.SetActive (true);
		idleSprite.GetComponent<SpriteRenderer> ().enabled = false;

		Instantiate (blast, shotSpawn.transform.position,shotSpawn.transform.rotation);
		Invoke ("revert", 1f);
	}

	void revert(){
		fireSprite.SetActive (false);
		idleSprite.GetComponent<SpriteRenderer> ().enabled = true;
		Invoke ("delayDestroy", 1f);

	}

	void delayDestroy(){
		Destroy (gameObject);
	}
}
