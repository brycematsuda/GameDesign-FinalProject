using UnityEngine;
using System.Collections;

public class QueryChanPachinkoController : MonoBehaviour {
	QuerySDMecanimController animController;
	public float moveSpeed;
	public float jumpBoost;
	public float jumpHeight;
	public int coolDownFrames;
	public int jumpCoolFrames;
	private int savedCool;
	private bool isJumping = false;
	private int jumpCoolSaved;

	// Use this for initialization
	void Start () {
		animController = GetComponent<QuerySDMecanimController> ();
		savedCool = coolDownFrames;
	}





	void FixedUpdate(){
		if (!isJumping) {
			
			Vector3 velocity = new Vector3 (0, 0, 0);
			//transform.rotation = Quaternion.Euler (0, transform.rotation.y, transform.rotation.z);
			//velocity = transform.TransformDirection(velocity);
			if (Input.GetKey (KeyCode.A)) {
				velocity += new Vector3 (0, 0, moveSpeed);
				animController.ChangeAnimation (QuerySDMecanimController.QueryChanSDAnimationType.NORMAL_RUN, true);
				if (Input.GetKey (KeyCode.W)) {
					transform.rotation = Quaternion.Euler (0, 225, 0);
				} else if (Input.GetKey (KeyCode.S)) {
					transform.rotation = Quaternion.Euler (0, 135, 0);
				} else {
					transform.rotation = Quaternion.Euler (0, 180, 0);
				}
			} else if (Input.GetKey (KeyCode.D)) {
				velocity += new Vector3 (0, 0, moveSpeed);
				animController.ChangeAnimation (QuerySDMecanimController.QueryChanSDAnimationType.NORMAL_RUN, true);
				if (Input.GetKey (KeyCode.W)) {
					transform.rotation = Quaternion.Euler (0, 315, 0);
				} else if (Input.GetKey (KeyCode.S)) {
					transform.rotation = Quaternion.Euler (0, 45, 0);
				} else {
					transform.rotation = Quaternion.Euler (0, 0, 0);
				}
			} else if (Input.GetKey (KeyCode.W)) {
				animController.ChangeAnimation (QuerySDMecanimController.QueryChanSDAnimationType.NORMAL_RUN, true);
				velocity += new Vector3 (0, 0, moveSpeed);
				transform.rotation = Quaternion.Euler (0, 270, 0);
			} else if (Input.GetKey (KeyCode.S)) {
				animController.ChangeAnimation (QuerySDMecanimController.QueryChanSDAnimationType.NORMAL_RUN, true);
				velocity += new Vector3 (0, 0, moveSpeed);
				transform.rotation = Quaternion.Euler (0, 90, 0);
			} else {
				animController.ChangeAnimation (QuerySDMecanimController.QueryChanSDAnimationType.NORMAL_IDLE, true);
				coolDownFrames = savedCool;
			}

			if (Input.GetKeyDown (KeyCode.Space)) {
				isJumping = true;
				animController.ChangeAnimation (QuerySDMecanimController.QueryChanSDAnimationType.NORMAL_FLY_STRAIGHT, true);
				velocity *= jumpBoost;
				transform.localPosition = new Vector3 (transform.localPosition.x, jumpHeight, transform.localPosition.z + velocity.z * Time.fixedDeltaTime);
			}
			if (velocity.z > 0 && coolDownFrames > 0) {
				coolDownFrames--;
			} else {
				velocity = transform.TransformDirection (velocity);
				transform.localPosition += velocity * Time.fixedDeltaTime;
			}

			if (isJumping) {
				if (jumpCoolFrames > 0) {
					jumpCoolFrames--;
				} else {
					isJumping = false;
				}
			}
		}
	}
}
