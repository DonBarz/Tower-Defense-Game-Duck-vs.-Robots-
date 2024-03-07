using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
        game_logic.level=1;
        game_logic.game_has_started = true;
        game_logic.time_modi = 1;
    }
    public void PlayGame1()
    {
        SceneManager.LoadSceneAsync(1);
        game_logic.level=2;
        game_logic.game_has_started = true;
        game_logic.time_modi = 1;
    }
    public void PlayGame2()
    {
        SceneManager.LoadSceneAsync(1);
        game_logic.level=3;
        game_logic.game_has_started = true;
        game_logic.time_modi = 1;
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
