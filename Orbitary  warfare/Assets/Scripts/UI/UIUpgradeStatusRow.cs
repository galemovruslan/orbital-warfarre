using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UIUpgradeStatusRow : MonoBehaviour
{
    [SerializeField] private GameObject _icon;
    [SerializeField] private EventAsset OnStatusChanged;

    private int _level;
    private List<GameObject> _iconList = new List<GameObject>();

    private void OnEnable()
    {
        OnStatusChanged.AddListener(ChangeLevel);
    }

    private void OnDisable()
    {
        OnStatusChanged.RemoveListener(ChangeLevel);
    }

    public void ChangeLevel(int newLevel)
    {
        if(_level < newLevel)
        {
            EraseRow();
        }
        FillRow(newLevel);
        _level = newLevel;
    }

    private void FillRow(int newLevel)
    {
        int levelDiff = newLevel - _level;

        for (int i = 0; i < levelDiff; i++)
        {
            GameObject newIcon = Instantiate(_icon, transform);
            _iconList.Add(newIcon);
        }
    }

    private void EraseRow()
    {
        foreach (var icon in _iconList)
        {
            Destroy(icon);
        }
        _iconList.Clear();
        _level = 0;
    }

}
