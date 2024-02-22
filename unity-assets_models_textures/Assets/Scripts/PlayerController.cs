using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Rigidbody player;

    public float move = 3000f;
    public float jump = 1000f;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //SceneManager.LoadScene("menu");
        }

        CheckFall();
    }

    IEnumerator LoadScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("maze");
    }

    void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            player.AddForce(move * Time.deltaTime,0,0);
        }
        if (Input.GetKey("a"))
        {
            player.AddForce(-move * Time.deltaTime,0,0);
        }
        if (Input.GetKey("w"))
        {
            player.AddForce(0,0, move * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            player.AddForce(0,0, -move * Time.deltaTime);
        }
        if (Input.GetKey("space"))
        {
            player.AddForce(0,jump * Time.deltaTime,0);
        }
    }

    void CheckFall()
    {
        // Define the bottom of the screen
        float screenBottom = -10f; // Adjust this value as needed

        // If the player has fallen off the screen
        if (transform.position.y < screenBottom)
        {
            // Reset the player's position to the top of the screen
            transform.position = new Vector3(transform.position.x,  200, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            //Debug.Log("You win!");
            //WinLoseText.text = "You Win!";
            //WinLoseBG.gameObject.SetActive(true);
        }
    }
}
