using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D;
using static UnityEngine.GraphicsBuffer;


public class tower2_script : MonoBehaviour, IPointerClickHandler
{
    SpriteRenderer[] rangeRenderers;
    SpriteRenderer rangeRenderer;

    Transform[] rangeTransforms;
    Transform rangeTransform;

    bool show_range;
    int towerID;

    public Collider2D coll;
    public SpriteRenderer towerRenderer;

    float tower_dir;
    float minDist;
    Transform tMin;

    int cost = 250;

    bool is_placing = true;
    bool can_place = true;
    GameObject[] enemies;
    Transform enemies_pos;
    float enemy_distance;

    int pen = 2;

    float fire_cooldown;
    float firerate = 1f;   //für zeitabstände zwischen einzelnen Schüssen
    float max_range = 1f;
    public GameObject Schuss;

    void Start()
    {
        rangeTransforms = GetComponentsInChildren<Transform>();
        rangeTransform = rangeTransforms[1];
        rangeTransform.localScale = Vector3.one * max_range * 2;

        rangeRenderers = GetComponentsInChildren<SpriteRenderer>();
        rangeRenderer = rangeRenderers[1];

        showRange();

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

    void Update()
    {
        if (towerID == game_logic.recentTowerID)
        {
            show_range = true;
            game_logic.Tower_selected = true;
        }
        else
        {
            show_range = false;
        }

        //enten platzieren////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //nur wenn am platzieren-wird ausgeführt
        if (is_placing){

                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

            //Platziermodus deaktivieren
            if (Input.GetKeyDown("t") | Input.GetKeyDown("escape"))
            {
                tower_placing.is_placing = false;
                Destroy(gameObject);
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (can_place)
                {
                    if (game_logic.money >= cost & can_place)
                    {
                        game_logic.money -= cost;
                        tower_placing.is_placing = false;
                        is_placing = false;
                    }
                    else
                    {
                        tower_placing.is_placing = false;
                        Destroy(gameObject);
                    }
                }
                else
                {
                    tower_placing.is_placing = false;
                    Destroy(gameObject);
                }
            }

            

            if (can_place & game_logic.money >= cost)
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
        //wenn nicht platziert wird
        else
        {

            //aktivieren des colliders (für andere türme)
            coll.isTrigger = false;
            //setzen der farbe auf undurchsichtig
            towerRenderer.color = new Color(1, 1, 1, 1f);

            //Quietscheente Platzieren////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (show_range)
            {
                rangeRenderer.enabled = true;
            }
            else
            {
                rangeRenderer.enabled = false;
            }

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


            if (minDist <= max_range)
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


                if (fire_cooldown <= 0) 
                {
                    Instantiate(Schuss,new Vector3(transform.position.x, transform.position.y , pen), Quaternion.Euler(0, 0, tower_dir * -1 + 180));
                    fire_cooldown = firerate;
                }



            }

            fire_cooldown -= Time.deltaTime; //zeit zwischen Schüssen

        }



    }

    //funktion für die animationen
    //für jeden drehwinkel wird eine der acht drehrichtungen (als wahrheitswert) ausgerechnet und an den animator controller übergeben
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (!is_placing)
        {
            if (towerID == game_logic.recentTowerID)
            {
                unshowRange();
            }
            else
            {
                showRange();
            }
        }
    }

    public void showRange()
    {
        int ID = 0;

        while (ID == 0 | ID == game_logic.recentTowerID)
        {
            ID = new System.Random().Next();
        }

        towerID = ID;
        game_logic.recentTowerID = ID;
        game_logic.newTowerSelected = true;

    }

    public void unshowRange()
    {
        int ID = 0;

        while (ID == 0 | ID == game_logic.recentTowerID)
        {
            ID = new System.Random().Next();
        }

        towerID = ID;
        

    }
}