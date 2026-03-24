using UnityEngine;

public class Paintball : MonoBehaviour
{
    [Header("Projectile Settings")]
    public float throwForce = 10f;  // Initial force when thrown

    [Header("Decal Settings")]
    public GameObject decalPrefab;  // Assign your decal projector prefab here
    public float decalOffset = 0.01f;  // Small offset to prevent z-fighting

    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody and apply a forward force
        rb = GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Get the first contact point
        ContactPoint contact = collision.contacts[0];

        // Determine the rotation so the decal faces the surface (using the contact normal)
        Quaternion decalRotation = Quaternion.LookRotation(contact.normal);

        // Calculate position with a slight offset along the normal to avoid surface clipping
        Vector3 decalPosition = contact.point + contact.normal * decalOffset;

        // Instantiate the decal projector at the contact point
        GameObject decalInstance = Instantiate(decalPrefab, decalPosition, decalRotation);

        // Optional: parent the decal to the impacted object so it moves with it
        decalInstance.transform.SetParent(collision.transform);

        // Optionally destroy the paintball after impact
        Destroy(gameObject);
    }
}
