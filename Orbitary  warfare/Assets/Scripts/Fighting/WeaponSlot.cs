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
    [SerializeField] private EventAsset OnLevelUp;

    private void Start()    
    {
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
            weapon.DisableWeapon();
        }

        foreach (var index in layoutItem.EnabledWeapons)
        {
            _weapons[index - 1].EnableWeapon();
        }

        if (OnLevelUp == null) { return; }
        OnLevelUp.Invoke(_level);
    }

}
