using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waves_script : MonoBehaviour{
    // Start is called before the first frame update

    
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    public static float[] waves = new float[26] {
                                            2,                  //welle1; jeder block beschreibt eine welle; hierbei ist die erste zahl die anzahl der stufen, und die aufeinanderfolgenden vierer-blöcke die einzelnen stufen
                                            1,10,2f,1,         //alle vier aufeinandefolgenden Zahlen beschreiben eine stufe; Dabei sind die ersten beiden Art und Anzahl der Gegner, die dritte der Abstand zwischen den Gegnern und die vierte der Abstand zur nächsten stufe
                                            1,10,0.5f,5f,

                                            4,
                                            2,500,0.1f,0,
                                            1,10,0.5f,0,
                                            2,5,0.25f,0,
                                            2,20,1f,0


                                            };

    public static int clone_count;
    public static int cloned_count;
    
    float timer = 0;        //für zeitabstände zwischen den stufen
    float spawnTimer = 0;   //für zeitabstände zwischen erschienenen gegnern

    int counter;
    int stage;
    public static int wave;


    void Start()
    {
        wave = 1;
        stage = 0;
        counter = 0;
        clone_count = 0;
        cloned_count = 0;
    }



    void Update()
    {
        if (game_logic.time_modi > 0)//nur falls die zeit nicht angehalten ist...
        {
            spawnTimer += Time.deltaTime * game_logic.time_modi;
            timer += Time.deltaTime * game_logic.time_modi;

            if (wave <= 2)
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
                        wave++;
                        cloned_count = 0;
                        stage = 0;
                        counter = 0;

                    }



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
