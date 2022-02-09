using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Health _health;
    private Bank _bank;
    private Shield _shield;

    public Health Health { get => _health; }
    public Bank Bank { get => _bank; }
    public Shield Shield { get => _shield;  }

    private void Awake()
    {
        _health = GetComponent<Health>();
        _bank = GetComponent<Bank>();
        _shield = GetComponentInChildren<Shield>();
    }

}
