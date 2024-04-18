using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Rigidbody player;
    public GameObject grassPlatformPrefab; // Assign your grass platform prefab in the inspector
    public GameObject tilePlatformPrefab; // Assign your tile platform prefab in the inspector
    public float move = 3000f;
    public float jump = 1000f;
    public float platformSpawnDistance = 5f; // Distance from the player where the platform will spawn

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
        // Get the horizontal and vertical input values
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Apply force based on the input values
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        player.AddForce(moveDirection * move * Time.deltaTime);

        // Check for jump input
        if (Input.GetButton("Jump"))
        {
            player.AddForce(new Vector3(0, jump * Time.deltaTime, 0));
            SpawnPlatform();
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

    void SpawnPlatform()
    {
        // Calculate the spawn position
        Vector3 spawnPosition = transform.position + transform.forward * platformSpawnDistance;
        spawnPosition.y -= 2f; // Adjust this value to ensure the platform spawns above the player

        // Randomly select between grass and tile platform prefabs
        GameObject platformPrefab = Random.value > 0.5f ? grassPlatformPrefab : tilePlatformPrefab;

        // Instantiate the platform
        Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
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
