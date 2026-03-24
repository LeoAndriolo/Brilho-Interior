using UnityEngine;
using UnityEngine.UI; // Required for UI interactions

public class PaintballShooter : MonoBehaviour
{
    public GameObject paintballPrefab;
    public Transform firePoint; // Assign where the paintball should be shot from
    
    [Header("Anxiety Settings")]
    public float maxAnxiety = 100f;
    public float anxiety;
    public float anxietyDepletion = 10f; // How much anxiety is lost per shot
    public float anxietyRegenRate = 10f; // Anxiety regenerated per second
    public Image anxietyBarUI; // Assign in the inspector

    private void Start()
    {
        anxiety = maxAnxiety; // Start with full anxiety
    }

    private void Update()
    {
        // Regenerate anxiety over time
        if (anxiety < maxAnxiety)
        {
            anxiety += anxietyRegenRate * Time.deltaTime;
            anxiety = Mathf.Clamp(anxiety, 0, maxAnxiety);
        }

        // Update UI
        if (anxietyBarUI != null)
            anxietyBarUI.fillAmount = anxiety / maxAnxiety;

        // Shooting logic
        if (Input.GetMouseButtonDown(0) && anxiety >= anxietyDepletion && !PauseMenu.isPaused) // Only shoot if anxiety is sufficient
        {
            Shoot();
        }

    }

    private void Shoot()
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

        // Deplete anxiety
        anxiety -= anxietyDepletion;
        anxiety = Mathf.Clamp(anxiety, 0, maxAnxiety);
    }
}
