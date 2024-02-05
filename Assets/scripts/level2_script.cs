using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2_script : MonoBehaviour
{

    float[] XYpos_want;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (game_logic.level == 2) {
            transform.position = new Vector3(0,0,-1);
            game_logic.XYpos_wants = new float[16]{     -4.32f,3.52f, // die zwei Zahlen sind die X und Y - Koordinaten der Wegpunkte, die ein Gegner nacheinander abgeht
                                                        -4.32f,-2.08f, //dabei ist jede erste eine X und jede zweite eine Y Koordinate
                                                        4.16f,-2.08f,
                                                        4.16f,2.24f,
                                                        0f,2.24f,
                                                        0f,0.16f,
                                                        -3.2f,0.16f,
                                                        -3.2f,-3.52f
                                                        };
        }
        else
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
