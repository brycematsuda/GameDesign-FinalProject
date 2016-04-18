using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverHit : MonoBehaviour
{
    public GUIText messageText;
	public DoorsCamControl cameras;
	public GameObject cam;
	private string message;
	private GameObject player;
	private Vector3 origPlayerPos;
	private bool moveBack = false;
	private UnityChanDoors uc2;
	private bool doRestart = false;
	private DoorsGameController dgc;
	Animator playerAnimator;

    // Use this for initialization
    void Start()
    {
        message = "Better luck next time!";
		player = GameObject.FindGameObjectWithTag ("Orange");
		origPlayerPos = player.transform.position;
		uc2 = player.GetComponent<UnityChanDoors> ();
		playerAnimator = player.GetComponent<Animator> ();
		cameras = cam.GetComponent<DoorsCamControl> ();
		dgc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<DoorsGameController> ();
		//playerAnimator.SetBool ("PushedBack", true);

    }

    // Update is called once per frame
    void Update()
    {
		if (moveBack) {
			player.transform.position = Vector3.MoveTowards (player.transform.position, origPlayerPos, 29 * Time.deltaTime);
		}
		if (player.transform.position == origPlayerPos) {
			moveBack = false;
			uc2.controlsEnabled = true;
			playerAnimator.SetBool ("PushedBack", false);
			player.GetComponent<CapsuleCollider> ().isTrigger = false;
			if (doRestart) {
				doRestart = false;
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}

		}
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Orange")
        {
            //messageText.text = message;
			//moveBack = true;
			//uc2.controlsEnabled = false;
            //StartCoroutine(Waiter());

            
        }
    }

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Orange") {
			moveBack = true;
			uc2.controlsEnabled = false;
			playerAnimator.SetBool ("PushedBack", true);
			player.GetComponent<CapsuleCollider> ().isTrigger = true;
			cameras.reset ();
			doRestart = true;
			dgc.loseLife ();
		}
	}
    IEnumerator Waiter()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
    }


}