using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class level2_collision : MonoBehaviour
{
    // Start is called before the first frame update

    public new TilemapCollider2D collider;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (game_logic.level != 2)
        {
            collider.enabled = false;
        }
        else
        {
            collider.enabled = true;
        }
    }
}
