using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.U2D;
using static UnityEngine.GraphicsBuffer;


public class tower_script : MonoBehaviour
{
    public Collider2D coll;
    public SpriteRenderer towerRenderer;

    public Animator anim;

    float tower_dir;
    float minDist;
    Transform tMin;

    bool is_placing = true;
    bool can_place = true;
    GameObject[] enemies;
    Transform enemies_pos;
    float enemy_distance;
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (is_placing)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

            //Platziermodus deaktivieren
            if (Input.GetKeyDown("t") | Input.GetKeyDown("escape"))
            {
                tower_placing.is_placing = false;
                Destroy(gameObject);
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (can_place)
                {
                    if (game_logic.money >= 250 & can_place)
                    {
                        game_logic.money -= 250;
                        tower_placing.is_placing = false;
                        is_placing = false;
                    }
                }
            }

            //Quietscheente Platzieren


            if (can_place)
            {
                //setzen der farbe auf weiß durchsichtig, wenn man am aktuellen ort plazieren kann
                towerRenderer.color = new Color(1, 1, 1, 0.65f);
            }
            else
            {
                //ansonsten wird der turm rot durchsichtig angezeigt
                towerRenderer.color = new Color(1, 0, 0, 0.65f);
            }

            //deaktivieren des colliders (und aktivieren des triggers)
            coll.isTrigger = true;
        }
        else
        {
            //aktivieren des colliders (für andere türme)
            coll.isTrigger = false;
            //setzen der farbe auf undurchsichtig
            towerRenderer.color = new Color(1, 1, 1, 1f);



            enemies = GameObject.FindGameObjectsWithTag("enemy");

            tMin = null;
            minDist = Mathf.Infinity;

            foreach (GameObject enemy in enemies)
            {
                if (Vector3.Distance(enemy.transform.position,transform.position) < minDist) {
                    minDist = Vector3.Distance(enemy.transform.position, transform.position);
                    tMin = enemy.transform;
                }

            }


            if (minDist <= 1)
            {
                float deltaY = transform.position.y - tMin.position.y;
                float deltaX = transform.position.x - tMin.position.x;

                //errechnet die position des nächsten gegners in grad (oben = 0°/360°, rechts = 90°, unten = 180°, links = 270°)

                tower_dir = (float)Math.Atan(deltaY / deltaX) * (180 / (float) Math.PI) - 90;

                if (tMin.position.x >= transform.position.x)
                {
                    tower_dir *= -1;
                }
                else
                {
                    tower_dir *= -1;
                    tower_dir += 180;
                }

                //print(tower_dir); //für test-zwecke


                //transform.rotation = Quaternion.Euler( 0 , 0 , tower_dir);


                tower_anim(tower_dir);


            }

        }



    }

    //funktion für die animationen
    //für jeden drehwinkel wird eine der acht drehrichtungen (als wahrheitswert) ausgerechnet und an den animator controller übergeben
    void tower_anim(float tower_dir)
    {

        towerRenderer.sortingOrder = (int)((transform.position.y) * -1000); //je weiter unten ein turm ist, desto weiter vorne wird er angezeigt

        if (tower_dir > 247.5f & tower_dir < 292.5f)
        {
            anim.SetBool("is_facing_left", true);
        }
        else
        {
            anim.SetBool("is_facing_left", false);
        }

        if (tower_dir > 337.5f | tower_dir < 22.5f)
        {
            anim.SetBool("is_facing_up", true);
        }
        else
        {
            anim.SetBool("is_facing_up", false);
        }

        if (tower_dir > 67.5f & tower_dir < 112.5f)
        {
            anim.SetBool("is_facing_right", true);
        }
        else
        {
            anim.SetBool("is_facing_right", false);
        }

        if (tower_dir > 157.5f & tower_dir < 202.5f)
        {
            anim.SetBool("is_facing_down", true);
        }
        else
        {
            anim.SetBool("is_facing_down", false);
        }
    }

    //falls der turm beim platzieren mit einem anderen turm, dem weg oder hindernissen auf der karte kollidiert, kann er nicht platziert werden
    void OnTriggerExit2D(Collider2D other)
    {
        can_place = true;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        can_place = false;
    }

}