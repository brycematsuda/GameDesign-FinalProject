using UnityEngine;
using System.Collections;

public class DebrisHit : MonoBehaviour {

	public AudioSource hitSound;
	private RagdollController collided;
	private CatapultGameController cgc;
	// Use this for initialization
	void Start () {
		cgc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<CatapultGameController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Player"){
			hitSound.Play ();
			//collided = other.gameObject.GetComponentInParent<RagdollController> ();
			//AudioSource pain = collided.audiencePain;
			//cgc.getExcited ();
			int maxIndex = cgc.getAudienceCheerLength ();
			int cheerToPlay = Random.Range (0, maxIndex);
			cgc.playCheer (cheerToPlay);
		}
	}
}
