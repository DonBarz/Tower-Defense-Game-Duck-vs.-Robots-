using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (game_logic.level == 1)
        {
            transform.position = new Vector3(0, 0, -1);
            game_logic.XYpos_wants = new float[18]{     -6f,1.92f, // die zwei Zahlen sind die X und Y - Koordinaten der Wegpunkte, die ein Gegner nacheinander abgeht
                                                        4.32f,1.92f, //dabei ist jede erste eine X und jede zweite eine Y Koordinate
                                                        4.32f,0f,
                                                        -1.44f,0f,
                                                        -1.44f,0.8f,
                                                        -4.32f,0.8f,
                                                        -4.32f,-1.92f,
                                                        2.4f,-1.92f,
                                                        2.4f,-3.5f,
                                                        };
        }
        else
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
