using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class WeaponSlot : MonoBehaviour
{
    [SerializeField] private ProgressionItem _layoutProgression;
    [Range(1, 3)]
    [SerializeField] private int _level;
    [SerializeField] private Weapon[] _weapons;


    private void Awake()
    {
        //_weapons = GetComponentsInChildren<Weapon>();
        Assert.IsNotNull(_weapons, "Weapons are not found");

        Assert.IsNotNull(_layoutProgression, "Layout progression is not assigned");
        UpdateLayout();
    }

    [ContextMenu("Level Up")]
    public void LevelUp()
    {
        if (_level >= _layoutProgression.MaxLevel) { return; }

        _level++;
        UpdateLayout();
    }

    private void UpdateLayout()
    {
        var layoutItem = _layoutProgression.GetItem(_level) as WeaponLayoutItem;
        foreach (var weapon in _weapons)
        {
            weapon.gameObject.SetActive(false);
        }
        foreach (var index in layoutItem.EnabledWeapons)
        {
            _weapons[index - 1].gameObject.SetActive(true);
        }
    }
}
