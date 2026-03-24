using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    [SerializeField] private string sceneToLoad; // Nome da cena a ser carregada

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter chamado por: " + other.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detectado, carregando cena " + sceneToLoad);
            Time.timeScale = 1;
            SceneManager.LoadScene("Stage 02");
        }
    }
}
