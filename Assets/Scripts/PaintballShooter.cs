using UnityEngine;

public class PaintballShooter : MonoBehaviour
{
    public GameObject paintballPrefab;
    public Transform firePoint; // Assign where the paintball should be shot from

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click to shoot
        {
            Instantiate(paintballPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
