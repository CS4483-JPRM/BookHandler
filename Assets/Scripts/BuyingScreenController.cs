using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyingScreenController : MonoBehaviour
{
    public GameObject screen;
    public static bool isBuyingScreen = false;
    public Button nextButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isBuyingScreen)
        {

        }
    }


    public void OpenBuyingScreen()
    {
        isBuyingScreen = true;
        Time.timeScale = 0f;
        screen.SetActive(true);
    }


    public void Resume()
    {
        isBuyingScreen = false;
        Time.timeScale = 1f;
        screen.SetActive(false);
        GameObject.FindObjectOfType<TimerController>().BeginTimer();
        GameObject.FindObjectOfType<CustomerSpawner>().cancelSpawner();
        GameObject.FindObjectOfType<CustomerSpawner>().setUpInitial();
    }
}
