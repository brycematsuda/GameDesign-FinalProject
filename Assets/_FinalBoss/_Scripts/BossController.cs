using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

	public GameObject[] shotSpawns, shotSpawns2, heartSpawns;
	public GameObject dijkstra, heart;
	private GameObject player;
	private int count = 0;
	private Vector3[] targs;
	int counter = 0;
	public bool doPatrol = false;
	private bool activ = false, doHearts = false;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		shotSpawns = GameObject.FindGameObjectsWithTag ("Dijkstra");
		shotSpawns2 = GameObject.FindGameObjectsWithTag ("Dijkstra2");
		heartSpawns = GameObject.FindGameObjectsWithTag ("HeartSpawn");
		foreach(GameObject x in shotSpawns){
			StartCoroutine(dijkstraShot(x.transform));
		}
//		foreach(GameObject x in shotSpawns2){
//			StartCoroutine(dijkstraShot2(x.transform));
//		}
		foreach(GameObject x in heartSpawns){
			StartCoroutine(heartShot(x.transform));
		}
		targs = new Vector3[] {new Vector3(-8.43f, 4.55f, 0),new Vector3(8.5f, 4.55f, 0)};
		//startPatrol ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator dijkstraShot(Transform spawn){
		while (true) {
			
			yield return new WaitForSeconds (Random.Range (0.5f, 1.5f));
			Vector3 target = player.transform.position;
			target.y = 0;
			target.z = 0;
			spawn.LookAt (target);
			//spawn.rotation = Quaternion.Euler (spawn.rotation.x, 90, 0);
			Instantiate (dijkstra, spawn.position, spawn.rotation);
		}
	}

	IEnumerator dijkstraShot2(Transform spawn){

			
			while (true) {
			if (activ) {
				
				Vector3 target = player.transform.position;
				target.y = 0;
				target.z = 0;
				spawn.LookAt (target);
				//spawn.rotation = Quaternion.Euler (spawn.rotation.x, 90, 0);
				Instantiate (dijkstra, spawn.position, spawn.rotation);
			}
			yield return new WaitForSeconds (Random.Range (0.5f, 1.5f));
		}
	}

	public void startPatrol(){
		StartCoroutine (patrol ());
	}

	IEnumerator patrol(){
		while (true) {
			Vector3 target = targs [count % 2];
			count++;
			//float shake = 1;
			for (int i = 0; i < 300; i++) {
				//target.y = target.y + shake;
				transform.position = Vector3.MoveTowards (transform.position, target, 10 * Time.deltaTime);
				//shake = -shake;
				yield return new WaitForSeconds (0.01f);
			}
		}
	}

	public void setActiv(){
		activ = true;
	}

	public void setHearts(){
		doHearts = true;
	}

	IEnumerator heartShot(Transform spawn){
		while (true) {
			if (doHearts) {
				Instantiate (heart, spawn.position, spawn.rotation);
			}
			yield return new WaitForSeconds (1f);
			//spawn.rotation = Quaternion.Euler (spawn.rotation.x, 90, 0);

		}
	}
}
