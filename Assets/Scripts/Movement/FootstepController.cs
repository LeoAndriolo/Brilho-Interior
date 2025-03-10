using UnityEngine;

public class FootstepController : MonoBehaviour
{
    // Array of footstep sounds for variety
    public AudioClip[] footstepClips;
    
    // Reference to the AudioSource component (assign via Inspector or get it in Start)
    public AudioSource footstepSource;
    
    // Interval between footstep sounds in seconds
    public float footstepInterval = 0.5f;
    private float footstepTimer = 0f;

    public LayerMask whatIsGround;
    
    // Reference to the movement component or check for velocity.
    // Replace with your specific movement logic. Here we assume a Rigidbody.
    private Rigidbody rb;

    void Start()
    {
        // If not assigned in Inspector, try to get the AudioSource from the GameObject.
        if (footstepSource == null)
            footstepSource = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Only play footsteps when the player is on the ground.
        // Adjust this condition if you use a CharacterController or your own ground detection.
        if (IsGrounded() && IsMoving())
        {
            footstepTimer += Time.deltaTime;
            if (footstepTimer >= footstepInterval)
            {
                PlayFootstep();
                footstepTimer = 0f;
            }
        }
        else
        {
            // Reset timer when not moving or in the air.
            footstepTimer = 0f;
        }
    }

    // Play a random footstep sound
    void PlayFootstep()
    {
        if (footstepClips.Length > 0)
        {
            int index = Random.Range(0, footstepClips.Length);
            footstepSource.PlayOneShot(footstepClips[index]);
        }
    }

    // Replace with your own ground check if needed.
    bool IsGrounded()
    {
        // Example: cast a ray downward from the player’s position.
        return Physics.Raycast(transform.position, Vector3.down, 2 * 0.5f + 0.2f, whatIsGround);

    }

    // Determine if the player is moving; adjust threshold as needed.
    bool IsMoving()
    {
        // Using the Rigidbody's velocity magnitude
        return rb.linearVelocity.magnitude > 0.1f;
    }
}
