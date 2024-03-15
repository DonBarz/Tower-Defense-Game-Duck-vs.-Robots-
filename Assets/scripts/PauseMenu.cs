using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {
        game_logic.paused = !game_logic.paused;
        pauseMenu.SetActive(game_logic.paused);
        if (game_logic.paused )
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void Resume()
    {
        game_logic.paused = false;
        pauseMenu.SetActive(game_logic.paused);
        Time.timeScale = 1;
    }

    public void Home()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1;
    }
}
