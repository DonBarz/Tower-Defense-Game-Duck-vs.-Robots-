using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waves_script : MonoBehaviour{
    // Start is called before the first frame update

    
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;

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
            2,
            1, 5, 1.5f, 5,
            1, 10, 0.5f, 0,

            1,
            1, 20, 0.2f, 0,

            2,
            1, 25, 0.5f, 0.5f,
            2, 5, 1.5f, 0.0f,

            2,
            1, 10, 0.5f, 0.0f,
            2, 15, 1f, 0.0f,

            3,
            2, 10, 1.0f, 5.0f,
            1, 25, 1.5f, 5.0f,
            2, 10, 0.1f, 0f,



            3,
            3, 5, 1.5f, 5,
            2, 10, 1.5f, 5,
            1, 15, 1.5f, 5,

            3,
            1, 15, 0.5f, 0,
            3, 10, 1.0f, 10,
            4, 1, 0.5f, 0,

            3,
            1, 25, 0.5f, 0.0f,
            2, 20, 1.0f, 0.0f,
            2, 15, 1.5f, 0.0f,

            2,
            1, 50, 0.1f, 10.0f,
            4, 25, 2.5f, 0.0f,

            7,
            1, 40, 0.25f, 0f,
            2, 20, 1f, 0f,
            4, 10, 0.25f, 0f,
            3, 15, 1f, 5f,
            1, 20, 1.25f, 0f,
            2, 25, 0.5f, 10f,
            5, 1, 0, 0f,



            25,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 0,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 10,
            3, 10, 1.0f, 10,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 0,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 10,
            3, 10, 1.0f, 10,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 0,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 10,
            3, 10, 1.0f, 10,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 0,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 10,
            3, 10, 1.0f, 10,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 0,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 10,
            3, 10, 1.0f, 10,

            1,
            1, 1000, 0.05f, 0,

            5,
            1, 25, 0.5f, 0.5f,
            2, 25, 0.5f, 0.5f,
            3, 25, 0.5f, 0.5f,
            4, 25, 0.5f, 0.5f,
            5, 3, 10f, 0.0f,

            5,
            5, 2, 2f, 3f,
            3, 20, 0.3f, 0.5f,
            4, 20, 0.3f, 0.5f,
            3, 20, 0.3f, 0.5f,
            4, 20, 0.3f, 0.5f,

            3,
            5, 10, 5f, 0f,
            1, 100, 0.1f, 5f,
            4, 25, 1f, 0f,


            };
            wave_count = 15;
        }

        if (game_logic.difficulty == 2)
        {
            waves = new float[] {
            2,
            1, 5, 1.5f, 5,
            1, 10, 0.5f, 0,

            1,
            1, 20, 0.2f, 0,

            2,
            1, 25, 0.5f, 0.5f,
            2, 5, 1.5f, 0.0f,

            2,
            1, 10, 0.5f, 0.0f,
            2, 15, 1f, 0.0f,

            3,
            2, 10, 1.0f, 5.0f,
            1, 25, 1.5f, 5.0f,
            2, 10, 0.1f, 0f,



            3,
            3, 5, 1.5f, 5,
            2, 10, 1.5f, 5,
            1, 15, 1.5f, 5,

            3,
            1, 15, 0.5f, 0,
            3, 10, 1.0f, 10,
            4, 1, 0.5f, 0,

            3,
            1, 25, 0.5f, 0.0f,
            2, 20, 1.0f, 0.0f,
            2, 15, 1.5f, 0.0f,

            2,
            1, 50, 0.1f, 10.0f,
            4, 25, 2.5f, 0.0f,

            7,
            1, 40, 0.25f, 0f,
            2, 20, 1f, 0f,
            4, 10, 0.25f, 0f,
            3, 15, 1f, 5f,
            1, 20, 1.25f, 0f,
            2, 25, 0.5f, 10f,
            5, 1, 0, 0f,



            25,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 0,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 10,
            3, 10, 1.0f, 10,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 0,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 10,
            3, 10, 1.0f, 10,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 0,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 10,
            3, 10, 1.0f, 10,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 0,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 10,
            3, 10, 1.0f, 10,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 0,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 10,
            3, 10, 1.0f, 10,

            1,
            1, 1000, 0.05f, 0,

            5,
            1, 25, 0.5f, 0.5f,
            2, 25, 0.5f, 0.5f,
            3, 25, 0.5f, 0.5f,
            4, 25, 0.5f, 0.5f,
            5, 3, 10f, 0.0f,

            5,
            5, 2, 2f, 3f,
            3, 20, 0.3f, 0.5f,
            4, 20, 0.3f, 0.5f,
            3, 20, 0.3f, 0.5f,
            4, 20, 0.3f, 0.5f,

            3,
            5, 10, 5f, 0f,
            1, 100, 0.1f, 5f,
            4, 25, 1f, 0f,


            };
            wave_count = 15;
        }

        if (game_logic.difficulty == 3)
        {
            waves = new float[] {
            2,
            1, 5, 1.5f, 5,
            1, 10, 0.5f, 0,

            1,
            1, 20, 0.2f, 0,

            2,
            1, 25, 0.5f, 0.5f,
            2, 5, 1.5f, 0.0f,

            2,
            1, 10, 0.5f, 0.0f,
            2, 15, 1f, 0.0f,

            3,
            2, 10, 1.0f, 5.0f,
            1, 25, 1.5f, 5.0f,
            2, 10, 0.1f, 0f,



            3,
            3, 5, 1.5f, 5,
            2, 10, 1.5f, 5,
            1, 15, 1.5f, 5,

            3,
            1, 15, 0.5f, 0,
            3, 10, 1.0f, 10,
            4, 1, 0.5f, 0,

            3,
            1, 25, 0.5f, 0.0f,
            2, 20, 1.0f, 0.0f,
            2, 15, 1.5f, 0.0f,

            2,
            1, 50, 0.1f, 10.0f,
            4, 25, 2.5f, 0.0f,

            7,
            1, 40, 0.25f, 0f,
            2, 20, 1f, 0f,
            4, 10, 0.25f, 0f,
            3, 15, 1f, 5f,
            1, 20, 1.25f, 0f,
            2, 25, 0.5f, 10f,
            5, 1, 0, 0f,



            25,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 0,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 10,
            3, 10, 1.0f, 10,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 0,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 10,
            3, 10, 1.0f, 10,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 0,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 10,
            3, 10, 1.0f, 10,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 0,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 10,
            3, 10, 1.0f, 10,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 0,
            2, 5, 0.5f, 0,
            4, 5, 0.5f, 10,
            3, 10, 1.0f, 10,

            1,
            1, 1000, 0.05f, 0,

            5,
            1, 25, 0.5f, 0.5f,
            2, 25, 0.5f, 0.5f,
            3, 25, 0.5f, 0.5f,
            4, 25, 0.5f, 0.5f,
            5, 3, 10f, 0.0f,

            5,
            5, 2, 2f, 3f,
            3, 20, 0.3f, 0.5f,
            4, 20, 0.3f, 0.5f,
            3, 20, 0.3f, 0.5f,
            4, 20, 0.3f, 0.5f,

            3,
            5, 10, 5f, 0f,
            1, 100, 0.1f, 5f,
            4, 25, 1f, 0f,


            };
            wave_count = 15;
        }
    }



    void Update()
    {
        spawnTimer += Time.deltaTime;
        print("-------------");
        print(clone_count);
        print(wave);
        print(stage);

        if (wave <= wave_count)
            {

                if (cloned_count < get_stages_clone_sum())  //falls alle gegner der wellen schon gespawnt worden sind
                {
                    if (counter >= waves[stage * 4 + 2 + get_wave_index()])
                    {
                        timer += Time.deltaTime;

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
                                spawner.spawn_enemy((int)waves[stage * 4 + 1 + get_wave_index()], game_logic.XYpos_wants[0], game_logic.XYpos_wants[1], 0, enemy1, enemy2, enemy3, enemy4, enemy5, 1);
                                cloned_count++;

                        }
                        }

                    }
                }
                else
                {

                    if (clone_count <= 0)
                    {
                        game_logic.money += (int) (150 / game_logic.difficulty );
                        wave++;
                        cloned_count = 0;
                        stage = 0;
                        counter = 0;

                    }



                }
            }
        


    }

        
    static int get_wave_index() {
        int index = 0;
        for (int i = 0; i < wave - 1; i++) 
        {
        index += (int) waves[index] * 4 + 1;
        }
        return index;
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
