using UnityEngine;
using System.Collections;

public class correctrotation : MonoBehaviour {
	float saved;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, 90, transform.localEulerAngles.z);
	}
}
