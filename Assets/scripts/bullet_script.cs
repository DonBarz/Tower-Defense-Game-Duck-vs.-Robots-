using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_script : MonoBehaviour
{
    float max_range = 0.2f; // *speed für echte max_range
    float speed = 5; //geschwindigkeit
    float rot; //richtung für berechnungen
    float pen = 1;  //gegner, die durchschossen werden können

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        pen -= 1;
        if (pen <= 0) 
        { 
            Destroy(gameObject);
        }
    }

    // Update is called once per frames
    void Update()
    {
        rot = transform.eulerAngles.z * (-Mathf.PI/180) + Mathf.PI;
        print(rot);
        

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
