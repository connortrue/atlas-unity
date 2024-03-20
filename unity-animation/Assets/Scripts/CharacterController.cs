using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Example : MonoBehaviour
{
    private CharacterController controller;
    private Camera playerCamera;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed =  2.0f;
    private float jumpHeight =  1.0f;
    private float gravityValue = -9.81f;

    void Start()
    {
        // Find the player GameObject in the scene
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            controller = player.GetComponent<CharacterController>();
            playerCamera = player.GetComponent<Camera>();
        }
        else
        {
            Debug.LogError("No GameObject with the tag 'Player' was found in the scene.");
        }
    }

    void Update()
    {
        if (controller == null) return;

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y <  0)
        {
            playerVelocity.y =  0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"),  0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        // Changes the height position of the player.
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        // Rotate the camera based on mouse input
        if (Input.GetMouseButton(1)) //  1 is the right mouse button
        {
            float mouseX = Input.GetAxis("Mouse X") * playerSpeed * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * playerSpeed * Time.deltaTime;

            playerCamera.transform.Rotate(Vector3.up * mouseX);
            playerCamera.transform.Rotate(Vector3.right * mouseY);
        }
    }
}
