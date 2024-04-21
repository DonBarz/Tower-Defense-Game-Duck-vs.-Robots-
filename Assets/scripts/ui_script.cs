using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ui_script : MonoBehaviour
{
    public Text moneyText;
    int money;

    public Text healthText;

    public Text waveText;
    int prevWave = 0;
    float waveTextOpac = 0;

    public Text gameOverText;
    float gameOverTextOpac = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameOverTextOpac = 0;
    }

    // Update is called once per frame
    void Update()
    {
        money = game_logic.money;

        moneyText.text = money.ToString();
        healthText.text = game_logic.hitpoints.ToString();

        waveText.text = waves_script.wave.ToString() + ". Welle";
        waveText.color = new Color(0,0,0,waveTextOpac);

        gameOverText.color = new Color(0, 0, 0, gameOverTextOpac);


        if (prevWave < waves_script.wave)
        {
            if (waveTextOpac >= 2)
            {
                prevWave = waves_script.wave;
            }
            else
            {
                waveTextOpac += 2f * Time.deltaTime;
            }
        }else
        {
            if (waveTextOpac > 0)
            {
                waveTextOpac -= 2f * Time.deltaTime;
            }
        }

        if(game_logic.hitpoints <= 0)
        {
            gameOverTextOpac += 5 * Time.deltaTime;
            waveTextOpac = 0;

            if (gameOverTextOpac >= 3)
            {
                SceneManager.LoadSceneAsync(0);//ändert Szene
            }
        }


    }
}
