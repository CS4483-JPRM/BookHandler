using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayController : MonoBehaviour
{
    public static int day;

    public Text dayCountTxt;
    // Start is called before the first frame update
    void Start()
    {
        day = 1;
        dayCountTxt.text = $"Day: {day}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementDay() {
        day += 1;
        dayCountTxt.text = $"Day: {day}";
    }
}
