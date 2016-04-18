using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class _SamuraiEnemyController : MonoBehaviour {

    private Rigidbody rb;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float triggerPoint;

    public GUIText messageText;
    private string message;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.localPosition.x > 51 || transform.localPosition.x < -51)
        {
            speed = speed * -1;
        }
	if(player.position.z > triggerPoint)
        {
            Vector3 velocity = new Vector3(speed, 0.0f, 0.0f);
        velocity = transform.TransformDirection(velocity);
        transform.localPosition += velocity * Time.fixedDeltaTime;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //messageText.text = message;

            //StartCoroutine(Waiter());
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    IEnumerator Waiter()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
    }
}
