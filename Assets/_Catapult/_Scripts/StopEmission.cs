using UnityEngine;
using System.Collections;

public class StopEmission : MonoBehaviour {
	EllipsoidParticleEmitter epe;
	public float whenToStop;
	// Use this for initialization
	void Start () {
		epe = GetComponent<EllipsoidParticleEmitter> ();
		Invoke ("stopEmitting", whenToStop);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void stopEmitting(){
		epe.emit = false;
	}
}
