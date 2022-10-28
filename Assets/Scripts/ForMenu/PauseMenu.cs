using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    [SerializeField] private GameObject InGameMenu;
    [SerializeField] private GameObject InGame;
    [SerializeField] private GameObject PlayableComponents;

    public void Pause()
    {
        InGame.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        InGame.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        /*
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        InGame.SetActive(false);
        InGameMenu.SetActive(true);
        PlayableComponents.SetActive(false);
        */
    }
}
