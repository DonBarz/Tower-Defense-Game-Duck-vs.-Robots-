using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_script : MonoBehaviour
{
    float max_range = 0.3f; // *speed für echte max_range
    float speed = 5; //geschwindigkeit
    float rot; //richtung für berechnungen
    public float pen = 2;  //gegner, die durchschossen werden können
    bool has_collided;


    // Start is called before the first frame update
    void Start()
    {
        pen = 2;
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (pen > 0 & !has_collided)
        {
            print(pen);

            has_collided = true;
            pen -= 1;
            other.GetComponent<movement_enemy>().dead = true;
        }
        if(pen <= 0)
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frames
    void Update()
    {
        has_collided = false;

        rot = transform.eulerAngles.z * (-Mathf.PI/180) + Mathf.PI;
        
            transform.position += new Vector3(
                  Mathf.Sin(rot) * Time.deltaTime * game_logic.time_modi * speed
                , Mathf.Cos(rot) * Time.deltaTime * game_logic.time_modi * speed
                , 0);

            max_range -= Time.deltaTime * game_logic.time_modi;

            if (max_range < 0)
            {
                Destroy(gameObject);
            }
        

    }
}
