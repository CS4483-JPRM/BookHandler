using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{
    public Text moneyText;
    public ParticleSystem cashierParticles;
    public AudioSource audioCash;

    public static float money;

    private static float moneyEarnedToday;

    void Awake()
    {
        money = 100f;
    }

    private void Start()
    {
        moneyText.text = string.Format("$ {0:N2}", money);
        moneyEarnedToday = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney(float add) {
        money += add;
        moneyEarnedToday += add;
        moneyText.text = string.Format("${0:N2}", money);
        cashierParticles.Play();
        audioCash.Play();
    }
    public void RemoveMoney(float remove)
    {
        money -= remove;
        moneyText.text = string.Format("${0:N2}", money);
        audioCash.Play();
    }

    public float GetMoney()
    {
        return money;
    }

    public float GetMoneyEarnedToday() {
        return moneyEarnedToday;
    }

    public void ResetDailyIncomeCounter()
    {
        moneyEarnedToday = 0;
    }
}
