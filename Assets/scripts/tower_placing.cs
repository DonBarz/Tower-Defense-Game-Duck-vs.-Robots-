using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower_placing : MonoBehaviour
{
    public static bool is_placing = false;
    public GameObject towersPrefab;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

        //Platziermodus aktivieren
        if (Input.GetKeyDown("t"))
        {
            if(!is_placing & game_logic.game_has_started)
            {
                is_placing = true;
                Instantiate(towersPrefab, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), transform.rotation);
            }
        }
    }
}
