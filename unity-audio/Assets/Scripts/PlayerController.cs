using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Rigidbody player;
    public GameObject grassPlatformPrefab;
    public GameObject tilePlatformPrefab;
    public float move = 3000f;
    public float jump = 1000f;
    public float platformSpawnDistance = 5f;

    private bool hasLandedOnNewPad = false; // Flag to track landing on a new pad

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
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        player.AddForce(moveDirection * move * Time.deltaTime);

        if (Input.GetButton("Jump"))
        {
            player.AddForce(new Vector3(0, jump * Time.deltaTime, 0));
        }
    }

    void CheckFall()
    {
        float screenBottom = -10f;

        if (transform.position.y < screenBottom)
        {
            transform.position = new Vector3(transform.position.x,  200, transform.position.z);
        }
    }

    void SpawnPlatform()
    {
        if (hasLandedOnNewPad)
        {
            Vector3 spawnPosition = transform.position + transform.forward * platformSpawnDistance;
            spawnPosition.y -= 2f;

            GameObject platformPrefab = Random.value > 0.5f ? grassPlatformPrefab : tilePlatformPrefab;
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);

            hasLandedOnNewPad = false; // Reset the flag after spawning
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pad")) // Assuming your pads have a "Pad" tag
        {
            hasLandedOnNewPad = true; // Set the flag to true when landing on a new pad
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            // Handle goal collision
        }
    }
}
