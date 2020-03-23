using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    public float speedUpFactor;

    public Text timeCounter;

    public TimeSpan timePlaying;
    private bool timerGoing;

    private float elapsedTime;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        timeCounter.text = "9:00 AM";
        timerGoing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsClosingTime() && 
            GameObject.FindObjectOfType<CustomerSpawner>().GetCustomerCount() == 0 &&
            !(EndOfDayController.DayIsOver || BuyingScreenController.isBuyingScreen) ) {
            EndTimer();
            GameObject.FindObjectOfType<EndOfDayController>().OpenEndOfDayScreen();
        }
    }

    public void BeginTimer()
    {
        timerGoing = true;
        //startTime = Time.time;
        elapsedTime = 32400f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer() {
        timerGoing = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing) {
            elapsedTime += Time.deltaTime * speedUpFactor;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);

            string timePlayingStr = "Time: " + timePlaying.ToString("h':'mm");
            timeCounter.text = timePlayingStr;

            yield return null;
        }
    }

    public bool IsClosingTime() {
        if (elapsedTime >= 72000f)
        { //75600
            //Debug.Log("Closing time!");
            return true;
        }
        else {
            return false;
        }
    }
}
