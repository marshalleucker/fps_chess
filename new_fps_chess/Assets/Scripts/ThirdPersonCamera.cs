// 2023-12-12 AI-Tag 
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;  // the player object
    public float distance = 5.0f;  // distance from the player
    public float xSpeed = 120.0f;  // camera x-axis rotation speed
    public float ySpeed = 120.0f;  // camera y-axis rotation speed

    private float x = 0.0f;
    private float y = 0.0f;

    private void Start()
    {
        var angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    private void LateUpdate()
    {
        if (target == null)
            return;

        x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
        y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

        var rotation = Quaternion.Euler(y, x, 0);
        var position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

        transform.rotation = rotation;
        transform.position = position;
    }
}
