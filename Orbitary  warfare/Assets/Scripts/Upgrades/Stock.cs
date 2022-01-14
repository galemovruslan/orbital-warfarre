using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stock : MonoBehaviour
{
    public static Stock Instance { get; private set; }

    [SerializeField] private TypedStock[] _items;

    private Dictionary< UpgradeType, StockItem> _upgradeMap = new Dictionary<UpgradeType, StockItem>();

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
        foreach (var item in _items)
        {
            _upgradeMap.Add(item.Type, item.Item);
        }
    }
    
    public ScriptableObject GetShield(UpgradeType type, int level)
    {
        return _upgradeMap[type].GetItem(level);
    }
    
    [System.Serializable]
    public struct TypedStock
    {
        public UpgradeType Type;
        public StockItem Item;
    }

}
