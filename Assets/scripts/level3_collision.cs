using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class level3_collision : MonoBehaviour
{
    // Start is called before the first frame update

    public TilemapCollider2D collider;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (game_logic.level != 3)
        {
            collider.enabled = false;
        }
        else
        {
            collider.enabled = true;
        }
    }
}
