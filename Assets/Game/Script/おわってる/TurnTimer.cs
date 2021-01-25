using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnTimer : MonoBehaviour
{
    float timer = 0f;
    float timercount;
    //表示するテキスト
    GameObject text;
    //制限時間
    private static float setSeconds = 60.0f;

    void Start()
    {
        text = this.transform.Find("Text").gameObject;
        timer = setSeconds;
    }

    // Update is called once per frame
    void Update()
    {


        if (timer > 0)
        {
            //1フレで増える時間を足し続けてる
            timercount += Time.deltaTime;
            timer = setSeconds - timercount;
            text.GetComponent<Text>().text = timer.ToString();
        }
        else
        {
            timer = +0.00f;
            timercount = 0.000f;
            text.GetComponent<Text>().text = timer.ToString();
        }
    }

    public void Timer()
    {
        if (timer > 0)
        {
            timercount = setSeconds;
            timer = 0.000f;
            text.GetComponent<Text>().text = timer.ToString();
        }
        else
        {
            timercount = 0;
            timer = setSeconds;
        }
    }
}
