using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.ExclusiveFullScreen, new RefreshRate() { numerator = 120, denominator = 1 });//setzen der aufl�sung f�r die bildschirmausgabe
    }

    public void PlayGame()//Knopf 1
    {
        game_logic.level = 1;//gibt das level an (1)
        SceneManager.LoadSceneAsync(1);//ändert Szene
        game_logic.game_has_started = true;
    }
    public void PlayGame1()//Knopf 2
    {
        game_logic.level = 2;//gibt das level an (2)
        SceneManager.LoadSceneAsync(1);//ändert Szene
        game_logic.game_has_started = true;
    }
    public void PlayGame2()//Knopf 3
    {
        game_logic.level = 3;//gibt das level an (3)
        SceneManager.LoadSceneAsync(1);//ändert Szene
        game_logic.game_has_started = true;
    }
    
    public void QuitGame()
    {
        Application.Quit();//beendet die Appplikation
    }
    public void difficulty1()
    {
        game_logic.difficulty = 1;//funktion für den knopf, der die schwierigkeit auf einfach setzt
    }
    public void difficulty2()
    {
        game_logic.difficulty = 2;//funktion für den knopf, der die schwierigkeit auf medium setzt
    }

    public void difficulty3()
    {
        game_logic.difficulty = 3;//funktion für den knopf, der die schwierigkeit auf schwierig setzt
    }
}
