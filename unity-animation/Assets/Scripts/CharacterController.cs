using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset; // Offset from the player's position
    private Vector3 lastMousePosition; // To store the last mouse position for delta calculation
    // Boolean for later inverted Y mode
    // public bool invertY = false;

    void Start()
    {
        // Initialize the last mouse position
        lastMousePosition = Input.mousePosition;
    }

    void LateUpdate()
    {
        // Update the camera's position to follow the player's position
        transform.position = player.position + offset;
        // Ensure the camera always faces the player
        transform.LookAt(player.position);
    }

    void Update()
    {
        // Rotate the camera based on mouse input
        if (Input.GetMouseButton(1)) // Right mouse button is pressed
        {
            float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime;

            // Calculate the delta mouse movement
            Vector3 delta = lastMousePosition - Input.mousePosition;
            lastMousePosition = Input.mousePosition;

            // Rotate the camera around the X axis
            transform.Rotate(Vector3.up, delta.x);

            // Rotate the camera around the Y axis
            // Replace line when boolean is made
            // transform.Rotate(Vector3.right, invertY ? delta.y : -delta.y);
            transform.Rotate(Vector3.right, -delta.y);
        }
    }
}
