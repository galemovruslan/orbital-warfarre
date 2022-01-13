using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stock : MonoBehaviour
{
    public static Stock Instance { get; private set; }

    [SerializeField] private StockShields _shields;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public ShieldItem GetShield(int level)
    {
        return _shields.GetItem(level) as ShieldItem;
    }

}
