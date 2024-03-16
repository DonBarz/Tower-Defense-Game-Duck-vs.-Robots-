using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class game_logic : MonoBehaviour
{
    public GameObject PauseMenu;
    public static bool paused;

    public static int difficulty;

    public static float[] XYpos_wants;


    public static int hitpoints = 100; //leben des spielers

    public static int money = 450; //währung des spielers

    public static int level = 1;

    public static bool game_has_started = true;

    public static int recentTowerID = 0;
    public static bool Tower_selected;
    public static bool newTowerSelected;

    void Start()
    {
        Time.timeScale = 1.0f;
        paused = false;

        money = 500 - 50 * difficulty;
        hitpoints = 125 - 25 * difficulty;
    }
    
    // Update is called once per frame
    void Update()
    {

        if (hitpoints <= 0) 
        {
            Time.timeScale = 0;
        }

            if (Input.GetKeyDown("escape")) //zum stoppen der zeit (+später öffnen des pausenmenüs)
        {
            //if (!tower_placing.is_placing & Tower_selected)
            //{
                //paused = !paused;

                //if (paused)
                //{
                    //Time.timeScale = 1;
                //}
                //else
                //{
                    //Time.timeScale = 0;
                //}

                //PauseMenu.SetActive(paused);
            //}
            //else 
            //{
                unSelect_towers();
            //}
         }

        Tower_selected = false;
        newTowerSelected = false;
          
    }

    public void unSelect_towers()
    {

        if (!newTowerSelected)
        {
            recentTowerID = 0;
        }
    }

}
