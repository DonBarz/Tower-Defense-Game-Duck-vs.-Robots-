using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerMenu : MonoBehaviour
{
    float XposWant;
    bool pulled_out = false;

    // Start is called before the first frame update
    void Start()
    {
        pulled_out = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pulled_out)
        {
            XposWant = 1760;
        }
        else
        {
            XposWant = 2115;
        }

        transform.position += Vector3.right * (XposWant - transform.position.x) * Time.deltaTime * 10;
        
        if (Input.GetKeyDown("escape"))
        {
            pulled_out = false;
        }

    }

    public void OnButtonClick() 
    {
        if (Time.timeScale > 0)
        {
            pulled_out = !pulled_out;
        }
    }


}
