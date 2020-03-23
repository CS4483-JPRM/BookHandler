using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndOfDayController : MonoBehaviour
{
    public GameObject screen;
    public Text dayText;
    public Text moneyEarnedText;
    public Text customerCountText;
    public Button nextButton;

    public static bool DayIsOver = false;
    // Start is called before the first frame update
    void Start()
    {
        updateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (DayIsOver)
        {

        }
        
    }

    private void updateText() {

        moneyEarnedText.text = $"Today's Income: $ {FindObjectOfType<MoneyController>().GetMoneyEarnedToday()}";
        customerCountText.text = $"Total Customer Count: {FindObjectOfType<CustomerSpawner>().GetTotalCustomerCount()}";
        dayText.text = $"Day {DayController.day}";
    }

    public void OpenEndOfDayScreen() {
        updateText();
        DayIsOver = true;
        Time.timeScale = 0f;
        screen.SetActive(true);
    }

    public void CloseEndOfDayScreen() {
        DayIsOver = false;
        Time.timeScale = 1f;
        screen.SetActive(false);
        GameObject.FindObjectOfType<SunController>().restartDay();
        GameObject.FindObjectOfType<DayController>().IncrementDay();
        GameObject.FindObjectOfType<MoneyController>().ResetDailyIncomeCounter();
    }
}
