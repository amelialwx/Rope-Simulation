using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public float zoomSpeed = 20.0f; // Increased zoom speed for faster response

    void Update()
    {
        // rotate camera based on mouse movement when right mouse button is held down
        if (Input.GetMouseButton(1)) // Right mouse button
        {
            float rotationX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float rotationY = -Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, rotationX, 0);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x + rotationY, transform.eulerAngles.y, 0);
        }

        // translate camera based on keyboard input using WASD keys
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float strafe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(strafe, 0, translation);

        // zoom in and out using the mouse scroll wheel, implemented as translation along the camera's local Z-axis
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(0, 0, scroll * zoomSpeed, Space.Self); // Use local space for direct forward/backward movement
    }
}
