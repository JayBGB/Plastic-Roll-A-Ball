using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 45f; // Speed of rotation in degrees per second
    public float hoverHeight = 0.5f; // Maximum height of hovering

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position; // Store the initial position for hovering calculation
    }

    void Update()
    {
        // Rotate the object around the Y-axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World); // Ensure rotation around global Y-axis

        // Calculate vertical movement (hovering)
        float hoverOffset = Mathf.Sin(Time.time) * hoverHeight;

        // Apply the final vertical movement to the object's position
        transform.position = initialPosition + new Vector3(0, hoverOffset, 0);
    }
}


