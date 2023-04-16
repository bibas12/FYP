using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject resultScreen;
    [SerializeField] bool startPlaying;
    [SerializeField] AudioSource theMusic;

    private bool isGamePaused = false;
    private bool hasGameRestarted = false;

    public void Pause()
    {
        Debug.Log("Game paused");
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
        AudioListener.pause = true; 
    }




    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        AudioListener.pause = false; // Resume the music
    }

    public void Restart(int sceneID)
    {
        Time.timeScale = 1f;
        //resultScreen.SetActive(false); // Disable the results screen
        SceneManager.LoadScene(sceneID);
        AudioListener.pause = false;
        //hasGameRestarted = true;



    }

    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }

    /*private void Update()
    {
        

        if (isGamePaused && resultScreen.activeSelf)
        {
            resultScreen.SetActive(false);
        }

        if (hasGameRestarted && !resultScreen.activeSelf && !startPlaying)
        {
            if (Input.anyKeyDown)
            {
                hasGameRestarted = false;
                resultScreen.SetActive(false);
                startPlaying = true; // Set startPlaying to true so that the game can start again
            }
        }
    }*/
}
