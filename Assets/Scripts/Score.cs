using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TextMesh scoreLabel,timeLabel,highLabel,overLabel;
    public GameObject reload;
    
    public static int score = 0;
    public float time = 60;
    string count;
    bool cont = true;


    // Start is called before the first frame update
    void Start()
    {
        highLabel.text = "Highest Kill " + PlayerPrefs.GetInt("HighestKill");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (cont) {
            time -= Time.deltaTime;
            if (time <= 0) {
                time = 0;
                cont = false;
                overLabel.text = "Gameover"+"\n Kill "+ score;
                scoreLabel.gameObject.SetActive(false);
                highLabel.gameObject.SetActive(false);
                timeLabel.gameObject.SetActive(false);
                //reload.gameObject.SetActive(true);
            }
        }

        //PlayerPrefs.SetInt("HighestKill", score);
        if (score > PlayerPrefs.GetInt("HighestKill"))
        {
            PlayerPrefs.SetInt("HighestKill", score);
        }
        else
        {
            PlayerPrefs.SetInt("HighestKill", PlayerPrefs.GetInt("HighestKill"));
        }

        count = time.ToString("f0");

        scoreLabel.text = "Kill:  " + score;
        timeLabel.text = "Time:  " + count;

    }
}
