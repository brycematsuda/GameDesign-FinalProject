﻿using UnityEngine;
using System.Collections;

public class OneDirectionCamFollow : MonoBehaviour {

	// Use this for initialization
	private Transform playerObj;
	void Start () {
		playerObj = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		transform.position = new Vector3 (playerObj.position.x + 4, transform.position.y, playerObj.position.z);
	}
}