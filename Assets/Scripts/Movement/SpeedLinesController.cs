using UnityEngine;

public class SpeedLinesController : MonoBehaviour
{
    // Reference the player's Rigidbody
    public Rigidbody playerRb;
    
    // Speed limit above which the effect will play
    public float speedThreshold = 5f;

    // We'll store the ParticleSystem component here
    private ParticleSystem ps;

    private void Start()
    {
        // Grab the ParticleSystem from the same GameObject
        ps = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        // Check current speed
        float currentSpeed = playerRb.linearVelocity.magnitude;

        // If speed is above the threshold, play the effect if not already playing
        if (currentSpeed > speedThreshold)
        {
            if (!ps.isPlaying)
                ps.Play();
        }
        else
        {
            // Otherwise stop it if it's running
            if (ps.isPlaying)
                ps.Stop();
        }
    }
}
