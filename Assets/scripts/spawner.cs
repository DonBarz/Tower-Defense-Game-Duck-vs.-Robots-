using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public static int enemy_tier;
    public static int enemy_already_done;
    public static float enemy_Xpos;
    public static float enemy_Ypos;

    public static bool spawned;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    //statische funktion zum erschaffen von gegnern; dabei werden die position, der fortschritt beim abgehen der wegpunkte, und die Art des gegners mitgegeben
    public static void spawn_enemy(int tier, float Xpos, float Ypos, int point_on_map, GameObject enemy1, GameObject enemy2, GameObject enemy3) { //man braucht einen anderen weg, die GameObjects in die static void zu bekommen

        enemy_already_done = point_on_map;
        enemy_tier = tier;
        enemy_Ypos = Ypos;
        enemy_Xpos = Xpos;
        waves_script.cloned_count++;
        waves_script.clone_count++;

        if (tier == 1)
        {
            Instantiate(enemy1, new Vector3(Xpos, Ypos, 0), new Quaternion( 0 , 0 , 0 , 0 ));
        }

        if (tier == 2)
        {
            Instantiate(enemy2, new Vector3(Xpos, Ypos, 0), new Quaternion( 0 , 0 , 0 , 0 ));
        }

        if (tier == 3)
        {
            Instantiate(enemy3, new Vector3(Xpos, Ypos, 0), new Quaternion( 0 , 0 , 0 , 0 ));
        }

        spawned = true;

    }
}
