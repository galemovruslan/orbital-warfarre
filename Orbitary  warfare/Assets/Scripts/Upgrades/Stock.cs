using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stock : MonoBehaviour
{
    public static Stock Instance { get; private set; }

    [SerializeField] private StockItem _shields;

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

    [ContextMenu("Get 2")]
    public void PeakItem2()
    {
        Debug.Log(GetShield(2).name);
    }


    public ShieldItem GetShield(int level)
    {
        return _shields.GetItem(level) as ShieldItem;
    }

}
