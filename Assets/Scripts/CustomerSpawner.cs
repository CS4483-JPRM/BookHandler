using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject CustomerSpawnee;
    public TimerController timeController;

    public bool stopSpawning;

    public float spawnTime;

    public float spawnDelay;

    private int customerCount;
    private int customerCountTotal;

    // Start is called before the first frame update
    void Start()
    {
        setUpInitial();
    }

    public void setUpInitial() {
        stopSpawning = false;
        InvokeRepeating("SpawnObject", spawnTime, Mathf.Floor(spawnDelay / (1 + DayController.day/2f ) ));
        customerCount = 0;
        customerCountTotal = 0;
    }

    void Update()
    {
        if (stopSpawning || timeController.IsClosingTime())
        {
            CancelInvoke("SpawnObject");
        }
    }
    public void cancelSpawner() {
        CancelInvoke("SpawnObject");
    }

    public void SpawnObject() {
        GameObject cust = Instantiate(CustomerSpawnee, transform.position, transform.rotation) as GameObject; ;
        CustomerController custController = cust.GetComponent<CustomerController>();
        custController.CustomerStartAction();
        IncrementCustomerCount();
        GameEvent.current.CustomerSpawned();
    }
    public int GetCustomerCount()
    {
        return customerCount;
    }
    public int GetTotalCustomerCount()
    {
        return customerCountTotal;
    }
    public int IncrementCustomerCount()
    {
        customerCount += 1;
        customerCountTotal += 1;
        return customerCount;
    }
    public int DecrementCustomerCount()
    {
        customerCount -= 1;
        return customerCount;
    }
}
