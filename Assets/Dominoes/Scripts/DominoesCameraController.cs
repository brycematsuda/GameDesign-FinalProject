﻿using UnityEngine;
using System.Collections;

public class DominoesCameraController : MonoBehaviour {

  public Transform player;
  public Vector3 offset;
  
  void Update () 
  {
      transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
  }
}
