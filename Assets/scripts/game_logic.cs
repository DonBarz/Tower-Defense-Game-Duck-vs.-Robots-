using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class game_logic : MonoBehaviour
{

    public static float[] XYpos_wants;


    public static float hitpoints = 10f; //leben des spielers

    public static float money = 25000f; //währung des spielers

    public static float time_modi = 0; //variale zum modifizieren der zeit

    public static int level = 1;

    public static bool game_has_started = false;

    public static bool main_menu_opened;

    void Start()
    {
        Screen.SetResolution(2560, 1440, fullscreenMode: FullScreenMode.MaximizedWindow, preferredRefreshRate: 120); //setzen der auflösung für die bildschirmausgabe
    }

    // Update is called once per frame
    void Update()
    {
        //print("health: " + hitpoints);
        if (Input.GetKeyDown("space")) //zum stoppen der zeit (+später öffnen des pausenmenüs)
        {
            if (time_modi == 0)
            {
                time_modi = 1;
                game_has_started=true;
            }
            else {
                time_modi = 0;
            }
        }

        if (Input.GetKeyDown("right")) //zum wechseln des levels
        {
            if (!game_has_started)
            {
                if (level >= 3)
                {
                    level = 1;
                }
                else
                {
                    level++;
                }

                print("Du spielst jetzt Karte " + level);
            }
            else {
                print("Du spielst Karte " + level + "!");
                print("Die Karte kann nachträglich nicht geändert werden (vorerst)!");
            }

        }

            if (Input.GetKeyDown("escape")) //zum stoppen der zeit (+später öffnen des pausenmenüs)
        {
                if (!tower_placing.is_placing)
                {
                    if (main_menu_opened)
                    {
                        main_menu_opened = false;
                    }
                    else
                    {
                        main_menu_opened = true;
                    }

                }
            }

        if (Input.GetKeyDown("q"))
        {
            if (main_menu_opened)
            {
                Application.Quit();
            }
        }
            
    }

    

}
