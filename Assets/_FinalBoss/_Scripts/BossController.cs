using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

	public GameObject[] shotSpawns;
	public GameObject dijkstra;
	private GameObject player;
	private int count = 0;
	private Vector3[] targs;
	int counter = 0;
	public bool doPatrol = false;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		shotSpawns = GameObject.FindGameObjectsWithTag ("Dijkstra");
		foreach(GameObject x in shotSpawns){
			StartCoroutine(dijkstraShot(x.transform));
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

	public void startPatrol(){
		StartCoroutine (patrol ());
	}

	IEnumerator patrol(){
		while (true) {
			Vector3 target = targs [count % 2];
			count++;
			float shake = 1;
			for (int i = 0; i < 300; i++) {
				target.y = target.y + shake;
				transform.position = Vector3.MoveTowards (transform.position, target, 6 * Time.deltaTime);
				shake = -shake;
				yield return new WaitForSeconds (0.01f);
			}
		}
	}
}
