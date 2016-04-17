using UnityEngine;
using System.Collections;

public class HubMovie : MonoBehaviour {

	Renderer r;
	MovieTexture movie;
	void Start(){
		r = GetComponent<Renderer>();
		movie = (MovieTexture)r.material.mainTexture;
		//movie.Stop ();
		movie.Play();
		movie.loop = true;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
