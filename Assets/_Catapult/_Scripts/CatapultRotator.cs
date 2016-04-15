using UnityEngine;
using System.Collections;

public class CatapultRotator : MonoBehaviour {

	public GameObject[] cannonParts;
	//Yes, this is a catapult. Shush.
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Get the mouse position
		Vector2 mousePos = Input.mousePosition;
		// Get the position of the mouse pointer relative to the world
		Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePos);
		foreach(GameObject part in cannonParts){
			Vector3 launcherAngle = part.transform.eulerAngles;
			launcherAngle.x = -Mathf.Atan2((mouseWorldPosition.y - transform.position.y), (mouseWorldPosition.x - transform.position.x)) * Mathf.Rad2Deg;
			//limit angle to -90 and 30
			if (launcherAngle.x < -90) {
				launcherAngle.x = -90;
			}
			if (launcherAngle.x > 30) {
				launcherAngle.x = 30;
			}
			part.transform.eulerAngles = launcherAngle;
		}


	}
}
