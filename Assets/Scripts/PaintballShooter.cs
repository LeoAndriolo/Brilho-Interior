using UnityEngine;

public class PaintballShooter : MonoBehaviour
{
    public GameObject paintballPrefab;
    public Transform firePoint; // Assign where the paintball should be shot from

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click to shoot
        {
            // Instantiate the paintball with the firePoint's rotation
            GameObject paintballInstance = Instantiate(paintballPrefab, firePoint.position, firePoint.rotation);
            
            // Find the decal child object (ensure its name matches)
            Transform decalTransform = paintballInstance.transform.Find("Decal");
            if (decalTransform != null)
            {
                // Apply a random rotation around the Z-axis only to the decal
                decalTransform.localRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
            }
        }
    }
}
