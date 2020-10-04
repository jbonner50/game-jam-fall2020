using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timer;
    private float seconds;
    private float minutes;

    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameObject.Find("Player").GetComponent<Player>().isAlive)
        {
            TimerCalculate();
        }
    }

    void TimerCalculate()
    {
        timer += Time.deltaTime;
        seconds = (int) (timer % 60);
        minutes = (int) (timer / 60);

        timerText.text = minutes.ToString ("00") + ":" + seconds.ToString ("00");


    }
}
