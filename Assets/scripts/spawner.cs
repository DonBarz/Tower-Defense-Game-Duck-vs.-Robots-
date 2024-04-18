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
    public static void spawn_enemy(int tier, float Xpos, float Ypos, int point_on_map, GameObject enemy1, GameObject enemy2, GameObject enemy3, GameObject enemy4, GameObject enemy5, int amount) { //man braucht einen anderen weg, die GameObjects in die static void zu bekommen

        enemy_already_done = point_on_map;
        enemy_tier = tier;
        enemy_Ypos = Ypos;
        enemy_Xpos = Xpos;
        waves_script.clone_count++;


        for (int i = 0; i < amount; i++)
        {
            if (tier == 1)
            {
                Instantiate(enemy1, new Vector3(Xpos, Ypos, 0), new Quaternion(0, 0, 0, 0));
            }

            if (tier == 2)
            {
                Instantiate(enemy2, new Vector3(Xpos, Ypos, 0), new Quaternion(0, 0, 0, 0));
            }

            if (tier == 3)
            {
                Instantiate(enemy3, new Vector3(Xpos, Ypos, 0), new Quaternion(0, 0, 0, 0));
            }

            if (tier == 4)
            {
                Instantiate(enemy4, new Vector3(Xpos, Ypos, 0), new Quaternion(0, 0, 0, 0));
            }

            if (tier == 5)
            {
                Instantiate(enemy5, new Vector3(Xpos, Ypos, 0), new Quaternion(0, 0, 0, 0));
            }

            waves_script.clone_count++;

        }

        spawned = true;

    }
}
