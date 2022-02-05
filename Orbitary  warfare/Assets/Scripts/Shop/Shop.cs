using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private ShopSlot[] _slots;
    private HashSet<ShopSlot> _selectedSlots;

    private void Awake()
    {
        _slots = GetComponentsInChildren<ShopSlot>();
    }

    private void OnEnable()
    {
        foreach (var slot in _slots)
        {
            slot.OnClick += Select;
        }
    }

    private void OnDisable()
    {
        foreach (var slot in _slots)
        {
            slot.OnClick -= Select;
        }
    }

    private void Select(ShopSlot slot)
    {
        if (slot.IsSelected)
        {
            _selectedSlots.Add(slot);
        }
        else
        {
            _selectedSlots.Remove(slot);
        }
    }

    
}
