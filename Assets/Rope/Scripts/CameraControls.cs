using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public float zoomSpeed = 20.0f; // increased zoom speed for faster response

    private CharacterController controller; // reference to the CharacterController

    void Start()
    {
        // get the CharacterController attached to the camera
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        // rotate camera based on mouse movement when right mouse button is held down
        if (Input.GetMouseButton(1))
        {
            float rotationX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float rotationY = -Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, rotationX, 0);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x + rotationY, transform.eulerAngles.y, 0);
        }

        // calculate translation and strafe based on keyboard input using WASD keys
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float strafe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        // create a move vector and use the CharacterController to move, handles collision
        Vector3 move = transform.TransformDirection(strafe, 0, translation);
        controller.Move(move);

        // zoom in and out using the mouse scroll wheel, implemented as translation along the camera's local Z-axis
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        // zoom movement vector
        Vector3 zoom = new Vector3(0, 0, scroll * zoomSpeed);
        // use CharacterController to handle zoom to ensure no clipping through objects
        controller.Move(transform.TransformDirection(zoom) * Time.deltaTime);
    }
}
