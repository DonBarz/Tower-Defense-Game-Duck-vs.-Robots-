using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_script : MonoBehaviour
{

    float max_range = 0.2f; // *speed für echte max_range
    float speed = 5; //geschwindigkeit
    float rot; //richtung für berechnungen
    public float pen = 2;  //gegner, die durchschossen werden können
    bool has_collided;


    // Start is called before the first frame update
    void Start()
    {
        pen = transform.position.z;
        transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (pen > 0 & !has_collided & other.GetComponent<movement_enemy>().dead == false)
        {
            //print(pen);//für testzwecke

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
                  Mathf.Sin(rot) * Time.deltaTime * speed
                , Mathf.Cos(rot) * Time.deltaTime * speed
                , 0);

            max_range -= Time.deltaTime;

            if (max_range < 0)
            {
                //speed = 0;
                Destroy(gameObject);
            }
        

    }
}
