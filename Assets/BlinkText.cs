using UnityEngine;
using System.Collections;

public class BlinkText : MonoBehaviour {
	public float interval = 0.5f;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("toggleActive", 0, interval);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void toggleActive(){
		gameObject.SetActive (!gameObject.active);
	}
}
