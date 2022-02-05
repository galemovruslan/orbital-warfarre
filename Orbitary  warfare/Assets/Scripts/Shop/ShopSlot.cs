using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class ShopSlot : MonoBehaviour, IPointerClickHandler
{
    public event Action<ShopSlot> OnClick;

    public bool IsSelected { get; private set; }

    [SerializeField] private ShopItem _item;

    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _cost;
    [SerializeField] private Color _default;
    [SerializeField] private Color _higlighted;

    private Image _background;
    private bool _isSold = false;

    private void Awake()
    {
        _background = GetComponent<Image>();
        Fill();
    }

    private void OnValidate()
    {
        if (_item != null)
        {
            Fill();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        IsSelected = !IsSelected;
        Highlight();
        OnClick?.Invoke(this);
    }

    private void Highlight()
    {
        _background.color = IsSelected ? _higlighted : _default;
    }


    private void Fill()
    {
        _name.text = _item.Name;
        _cost.text = _item.Price.ToString();
        _icon.sprite = _item.Sprite;
    }

}
