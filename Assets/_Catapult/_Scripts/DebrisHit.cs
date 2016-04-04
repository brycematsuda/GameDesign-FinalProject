using UnityEngine;
using System.Collections;

public class DebrisHit : MonoBehaviour {

	public AudioSource hitSound; //the sound to play if this piece of debris is hit
	private RagdollController collided;
	private CatapultGameController cgc;
	private AudienceReactionPoints arp;
	private bool onCooldown;

	// Use this for initialization
	void Start () {
		cgc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<CatapultGameController> ();
		arp = GameObject.FindGameObjectWithTag ("PointsText").GetComponent<AudienceReactionPoints> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Player"){
			hitSound.Play ();
			int maxIndex = cgc.getAudienceCheerLength ();
			int cheerToPlay = Random.Range (0, maxIndex);
			cgc.playCheer (cheerToPlay);
			if (!onCooldown) {
				string bodyPart = other.transform.name;
				switch (bodyPart) {
				case "Head":
					arp.spawnText ("HEAD TRAUMA, YA DINGUS: +20", 20);
					break;
				case "Leg":
					arp.spawnText ("LEG INJURY: +10",10);
					break;
				case "Arm":
					arp.spawnText ("ARM INJURY: +10",10);
					break;
				case "Pelvis":
					arp.spawnText ("FAMILY JEWELS: +40",40);
					break;
				case "Spine":
					arp.spawnText ("SPINE INJURY (YOU'LL NEVER WALK AGAIN): +20", 20);
					break;
				default:
					arp.spawnText ("HERP", 1);
					break;
				}
				onCooldown = true;
				StartCoroutine (cooldown());
				//arp.spawnText ("SELF-HARM: +10");
			}

		}
	}
	IEnumerator cooldown(){
		yield return new WaitForSeconds (1f);
		onCooldown = false;
	}
}
