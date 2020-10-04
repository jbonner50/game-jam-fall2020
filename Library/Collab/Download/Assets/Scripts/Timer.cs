using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float timer;
    float seconds;
    float minutes;

    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //TODO check if player is alive
        TimerCalculate();
    }

    void TimerCalculate()
    {
        timer += Time.deltaTime;
        seconds = timer % 60;
        minutes = timer / 60;

        timerText.text = minutes.ToString ("00") + ":" + seconds.ToString ("00");


    }
}
