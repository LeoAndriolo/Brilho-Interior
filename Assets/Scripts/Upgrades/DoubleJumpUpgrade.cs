using UnityEngine;

public class DoubleJumpUpgrade : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Verifique se o objeto que colidiu possui a tag apropriada.
        // Se o collider estiver em PlayerObj, certifique-se de que ele tenha a tag "PlayerObj"
        // ou altere a verificação para a tag que estiver sendo utilizada.
        if (other.CompareTag("Player"))
        {
            // Tenta obter o PlayerMovement do objeto pai (ou de um objeto na hierarquia)
            PlayerMovement playerMovement = other.GetComponentInParent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.hasDoubleJumpUpgrade = true;
            }
            // Desativa o upgrade após a coleta
            gameObject.SetActive(false);
        }
    }
}