using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.ExclusiveFullScreen, new RefreshRate() { numerator = 120, denominator = 1 });//setzen der auflösung für die bildschirmausgabe
    }

    public void PlayGame()//Knopf 1
    {
        game_logic.difficulty = 2;
        game_logic.level = 1;
        SceneManager.LoadSceneAsync(1);
        game_logic.game_has_started = true;
    }
    public void PlayGame1()//Knopf 2
    {
        game_logic.difficulty = 2;
        game_logic.level = 2;
        SceneManager.LoadSceneAsync(1);
        game_logic.game_has_started = true;
    }
    public void PlayGame2()//Knopf 3
    {
        game_logic.difficulty = 2;
        game_logic.level = 3;
        SceneManager.LoadSceneAsync(1);
        game_logic.game_has_started = true;
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
