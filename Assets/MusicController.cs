using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	public AudioSource[] songList;
	// Use this for initialization
	void Start () {
		int songToPlay = Random.Range (0, songList.Length);
		songList [songToPlay].Play();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
