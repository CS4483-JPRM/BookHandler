using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{

    public static GameEvent current;

    void Awake()
    {
        current = this;
    }

    public event Action onCustomerSpawn;
    public void CustomerSpawned() {
        if (onCustomerSpawn != null) {
            onCustomerSpawn();
        }
    }
}
