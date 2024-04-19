using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waves_script : MonoBehaviour{
    // Start is called before the first frame update

    
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    public static float[] waves;

    public static int clone_count;
    public static int cloned_count;
    
    float timer = 0;        //für zeitabstände zwischen den stufen
    float spawnTimer = 0;   //für zeitabstände zwischen erschienenen gegnern

    int counter;
    int stage;
    public static int wave;
    int wave_count;


    void Start()
    {
        wave = 1;
        stage = 0;
        counter = 0;
        clone_count = 0;
        cloned_count = 0;

        waves = new float[] {
            2,
            1, 1, 0, 2,
            2, 1, 0, 0
        };
        wave_count = 1;

        if (game_logic.difficulty == 1)
        {
            waves = new float[] {
            1,
            1, 10, 1.5f, 0,

            1,
            1, 20, 1f, 0,

            2,
            1, 20, 1.5f, 2,
            2, 5, 1f, 0,

            2,
            2, 10, 1f, 2,
            1, 10, 0.5f, 0,

            };
            wave_count = 4;
        }

        if (game_logic.difficulty == 2)
        {
            waves = new float[] {
            3,
            1, 45, 0.2f, 0,
            2, 50, 0.5f, 0,
            3, 35, 0.1f, 0,

            1,
            1, 20, 1f, 0,

            2,
            1, 20, 1.5f, 0.5f,
            2, 5, 1f, 0,

            2,
            2, 15, 1f, 2,
            1, 10, 0.5f, 0,

            };
            wave_count = 4;
        }

        if (game_logic.difficulty == 3)
        {
            waves = new float[] {
            1,
            1, 10, 1f, 0,

            2,
            1, 20, 0.75f, 0,

            2,
            1, 20, 1.5f, 0,
            2, 10, 1f, 0,

            2,
            2, 20, 1f, 0,
            1, 10, 0.1f, 0,

            };
            wave_count = 4;
        }
    }



    void Update()
    {
            spawnTimer += Time.deltaTime;
            timer += Time.deltaTime;

            if (wave <= wave_count)
            {

                if (cloned_count < get_stages_clone_sum())  //falls alle gegner der wellen schon gespawnt worden sind
                {
                    if (counter >= waves[stage * 4 + 2 + get_wave_index()])
                    {

                        if (timer >= waves[stage * 4 + 4 + get_wave_index()])
                        {
                            timer = 0;
                            if (stage < get_stages() - 1)
                            {
                                stage++;
                            }
                            counter = 0;

                        }
                    }
                    else
                    {
                        if (spawnTimer > waves[stage * 4 + 3 + get_wave_index()])
                        {
                            if (!spawner.spawned)
                            {
                                spawnTimer = 0;
                                counter++;
                                spawner.spawn_enemy((int)waves[stage * 4 + 1 + get_wave_index()], game_logic.XYpos_wants[0], game_logic.XYpos_wants[1], 0, enemy1, enemy2, enemy3);

                            }
                        }

                    }
                }
                else
                {

                    if (clone_count == 0)
                    {
                        game_logic.money += wave * 100 - wave * wave;
                        wave++;
                        cloned_count = 0;
                        stage = 0;
                        counter = 0;

                    }



                }
            }
        


    }

        
    static int get_wave_index() {
        float index = 0;
        for (int i = 0; i < wave - 1; i++) 
        {
        index += waves[(int)index] * 4 + 1;
        }
        return (int) index;
    }

    static int get_stages()
    {
        return (int)waves[(int)get_wave_index()];
    }

    static int get_stages_clone_sum()
    {
        int clone_sum = 0;
        for (int i = 0; i < get_stages(); i++)
        {
            clone_sum += (int) waves[get_wave_index() +  i * 4 + 2];
        }
        return clone_sum;
    }

}
