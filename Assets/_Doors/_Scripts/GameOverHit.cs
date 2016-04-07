using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverHit : MonoBehaviour
{
    public GUIText messageText;
    private string message;

    // Use this for initialization
    void Start()
    {
        message = "Better luck next time!";
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //messageText.text = message;

            StartCoroutine(Waiter());
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