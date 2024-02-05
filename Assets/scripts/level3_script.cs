using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level3_script : MonoBehaviour
{

    float[] XYpos_want;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (game_logic.level == 3)
        {
            transform.position = new Vector3(0, 0, -1);
            game_logic.XYpos_wants = new float[24]{     -6f,2.24f, // die zwei Zahlen sind die X und Y - Koordinaten der Wegpunkte, die ein Gegner nacheinander abgeht
                                                        3.84f,2.24f, //dabei ist jede erste eine X und jede zweite eine Y Koordinate
                                                        3.84f,0.64f,
                                                        -0.16f,0.64f,
                                                        -0.16f,-0.48f,
                                                        -3.52f,-0.48f,
                                                        -3.52f,-2.08f,
                                                        4.48f,-2.08f,
                                                        4.48f,-0.64f,
                                                        3.04f,-0.64f,
                                                        3.04f,-1.44f,
                                                        6f,-1.44f
                                                        };
        }
        else
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
