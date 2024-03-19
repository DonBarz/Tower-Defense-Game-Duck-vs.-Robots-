using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class movement_enemy : MonoBehaviour
{

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    private Animator anim;
    private SpriteRenderer sprite;
    private Collider2D coll;

    float Xpos_want;
    float Ypos_want;

    float deltaXpos;
    float deltaYpos;

    float deltaXY;
    float Yoffset = 0;

    int already_done;
    int enemy_tier;

    public bool dead = false;

    float death_waiting_timer = 0;
    float spawn_waiting_timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();

        transform.position = new Vector3(spawner.enemy_Xpos, spawner.enemy_Ypos, 0);
        //print(spawner.enemy_Xpos + "" + spawner.enemy_Ypos);

        already_done = spawner.enemy_already_done;
        enemy_tier = spawner.enemy_tier;

        set_enemy_speed();

        if (game_logic.XYpos_wants.Length - 2 > already_done)
        {
            Xpos_want = game_logic.XYpos_wants[already_done];
            Ypos_want = game_logic.XYpos_wants[already_done + 1] + Yoffset;
        }
        else
        {
            game_logic.hitpoints--;
            enemy_die();
        }

        spawner.spawned = false;

    }
    

    // Update is called once per frame
    void Update()
    {
        enemy_move();
    }

    void enemy_anim() {

        sprite.sortingOrder = (int) ((transform.position.y + Yoffset) * -1000); //je weiter unten ein gegner ist, desto weiter vorne wird er angezeigt

        if (Mathf.Abs(deltaXpos) > Mathf.Abs(deltaYpos) & deltaXpos > 0)
        {
            anim.SetBool("isGoingLeft", true);
        }
        else
        {
            anim.SetBool("isGoingLeft", false);
        }

        if (Mathf.Abs(deltaXpos) > Mathf.Abs(deltaYpos) & deltaXpos < 0)
        {
            anim.SetBool("isGoingRight", true);
        }
        else
        {
            anim.SetBool("isGoingRight", false);
        }

        if (Mathf.Abs(deltaXpos) < Mathf.Abs(deltaYpos) & deltaYpos > 0)
        {
            anim.SetBool("isGoingUp", true);
        }
        else
        {
            anim.SetBool("isGoingUp", false);
        }

        if (Mathf.Abs(deltaXpos) < Mathf.Abs(deltaYpos) & deltaYpos < 0)
        {
            anim.SetBool("isGoingDown", true);
        }
        else
        {
            anim.SetBool("isGoingDown", false);
        }

        if (spawn_waiting_timer <= 0)
        {
            anim.SetBool("spawn_done",true);
        }
        else
        {
            anim.SetBool("spawn_done", false);
        }

        if (dead)
        {
            anim.SetBool("dead", true);
        }
        else
        {
            anim.SetBool("dead", false);
        }
    }

    void enemy_move()
    {

            if (!dead)
            {
                if (spawn_waiting_timer > 0)
                {
                    spawn_waiting_timer -= Time.deltaTime;
                }

                if (spawn_waiting_timer <= 0)
                {
                    if (transform.position.x + 0.01 * deltaXY >= Xpos_want & transform.position.x - 0.01 * deltaXY <= Xpos_want
                    & transform.position.y + 0.01 * deltaXY >= Ypos_want & transform.position.y - 0.01 * deltaXY <= Ypos_want)
                    {
                        transform.position = new Vector3(Xpos_want, Ypos_want, 0);

                        if (game_logic.XYpos_wants.Length - 2 > already_done)
                        {

                            already_done += 2;

                            if (game_logic.XYpos_wants.Length > already_done)
                            {
                                Xpos_want = game_logic.XYpos_wants[already_done];
                                Ypos_want = game_logic.XYpos_wants[already_done + 1] + Yoffset;
                            }
                        }
                        else
                        {
                            game_logic.hitpoints--;
                            dead = true;
                        }
                    }
                    else
                    {

                        deltaXpos = transform.position.x - Xpos_want;
                        deltaYpos = Ypos_want - transform.position.y;

                        deltaXpos = deltaXY * deltaXpos / (float)System.Math.Sqrt(deltaXpos * deltaXpos + deltaYpos * deltaYpos);
                        deltaYpos = deltaXY * deltaYpos / (float)System.Math.Sqrt(deltaXpos * deltaXpos + deltaYpos * deltaYpos);

                        enemy_anim();

                        transform.position += (Vector3.up * deltaYpos * Time.deltaTime + Vector3.left * deltaXpos * Time.deltaTime);
                    //bewegt den gegner um den berechneten vektor

                }
                }
            }

            if (dead)
            {
                death_waiting_timer -= Time.deltaTime;
                if (death_waiting_timer <= 0)
                {
                    if (!spawner.spawned)
                    {
                        enemy_die();
                    }
                }
            }
        
    }

    void enemy_die()
        {

            waves_script.clone_count--;
            dead = true;

            if (enemy_tier == 2)
            {
                spawner.spawn_enemy(1, transform.position.x, transform.position.y - Yoffset / 2, already_done, enemy1, enemy2, enemy3);
            }

            if (enemy_tier == 3)
            {
                spawner.spawn_enemy(2, transform.position.x, transform.position.y - Yoffset / 2, already_done, enemy1, enemy2, enemy3);
            }

        //könnte man vereinfachen... ich möchte mir aber die freiheit lassen, bei manchen gegnern mehrere gegner oder gegner verschiedener arten zu spawnen
        //das in so ähnlich auch bei set_enemy_speed...
            game_logic.money++;
            Destroy(gameObject);
    }
        void set_enemy_speed()

        {
            if (enemy_tier == 1)
            {
                deltaXY = 0.5f;
                Yoffset = 0.2f;
            }

            if (enemy_tier == 2)
            {
                deltaXY = 1f;
                Yoffset = 0.45f;
            }

            if (enemy_tier == 3)
            {
                deltaXY = 0.8f;
                Yoffset = 0.1f;
            }
        }
}

