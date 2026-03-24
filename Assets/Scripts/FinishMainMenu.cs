using UnityEngine;

public class FinishMainMenu : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Reset time scale to ensure the new scene is interactive
            Time.timeScale = 1f;
            
            // Load scene 0 (or your intended scene)
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
