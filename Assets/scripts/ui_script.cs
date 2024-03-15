using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ui_script : MonoBehaviour
{
    public Text moneyText;
    int money;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        money = game_logic.money;

        moneyText.text = money.ToString();
    }
}
