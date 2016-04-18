using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour {
	public DoorsCamControl cameras;
	private UnityChanDoors ucd;
    // Use this for initialization
    void Start () {
		ucd = GameObject.FindGameObjectWithTag ("Orange").GetComponent<UnityChanDoors> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
		if(other.gameObject.tag == "Orange")
        {
			cameras.moveToNext ();
			ucd.moveToNext ();
            Destroy(this.gameObject);
        }
    }

}
