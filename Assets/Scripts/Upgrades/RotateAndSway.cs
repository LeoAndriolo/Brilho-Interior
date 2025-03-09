using UnityEngine;

public class RotateAndSway : MonoBehaviour
{
    // Adjust these values from the Inspector
    public float rotationSpeed = 45f;  // Degrees per second
    public float swayAmplitude = 0.5f;   // Maximum sway distance
    public float swayFrequency = 1f;     // How fast it sways

    private Vector3 startPosition;

    void Start()
    {
        // Store the starting position to base the sway on
        startPosition = transform.position;
    }

    void Update()
    {
        // Rotate the object around its Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Calculate the new vertical position for the sway effect
        float newY = startPosition.y + Mathf.Sin(Time.time * swayFrequency) * swayAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
