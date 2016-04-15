using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Randomizer : MonoBehaviour {

	int[] scenesToPlay = new int[6];
	int currentScene = 0;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < scenesToPlay.Length; i++) {
			scenesToPlay [i] = i + 1;
		}
		reshuffle (scenesToPlay);
		for (int i = 0; i < scenesToPlay.Length; i++) {
			Debug.Log (scenesToPlay[i]);
		}

		GameObject.DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void reshuffle(int[] texts)
	{
		// Knuth shuffle algorithm :: courtesy of Wikipedia :)
		for (int t = 0; t < texts.Length; t++ )
		{
			int tmp = texts[t];
			int r = Random.Range(t, texts.Length);
			texts[t] = texts[r];
			texts[r] = tmp;
		}
	}

	public void loadNextScene(){
		SceneManager.LoadScene (scenesToPlay [currentScene]);
		currentScene++;
	}

}
