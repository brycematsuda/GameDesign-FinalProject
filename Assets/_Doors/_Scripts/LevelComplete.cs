using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //messageText.text = message;

            StartCoroutine(Waiter());
            SceneManager.LoadScene(0);
        }
    }
    IEnumerator Waiter()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
    }


}
