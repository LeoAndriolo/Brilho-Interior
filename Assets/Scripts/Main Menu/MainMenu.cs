using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Load the game scene
        SceneManager.LoadScene("Stage 01");
    }

    public void GoToSettingsMenu()
    {
        // Load the settings menu scene
        SceneManager.LoadScene("SettingsMenu");
    }

    public void GoToMainMenu()
    {
        // Load the main menu scene
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        // Quit the game
        Application.Quit();
    }
}
