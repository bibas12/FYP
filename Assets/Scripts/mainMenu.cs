using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void LoadScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void StartGame(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void LoadGame()
    {
        // Load saved game data or load the first level of the game
        SceneManager.LoadScene("GameScene");
    }

    public void ViewHighScores()
    {
        SceneManager.LoadScene("HighScores");
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
