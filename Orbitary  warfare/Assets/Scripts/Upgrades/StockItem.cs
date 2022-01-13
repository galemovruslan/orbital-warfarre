using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StockItem<T> : ScriptableObject where T : ScriptableObject
{
    [SerializeField] private List<T> _stock = new List<T>();

    public T GetItem(int level)
    {
        int listIndex = level - 1;
        if (listIndex < 0 || listIndex >= _stock.Count)
        {
            return default(T);
        }
        return _stock[listIndex];
    }
}
