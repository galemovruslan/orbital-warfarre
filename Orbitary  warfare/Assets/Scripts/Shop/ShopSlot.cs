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
    public int Price { get => _item.Price;  }

    [SerializeField] private ShopItem _item;
    [SerializeField] private bool _isLimited;

    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _costText;
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
        if (_isSold && _isLimited) { return; }

        IsSelected = !IsSelected;
        Highlight();
        OnClick?.Invoke(this);
    }

    public void Buy(Vector3 position)
    {
        SpawnPickup(position);
        _isSold = true;
        _costText.text = "Sold";
        Unselect();
    }

    public void Unselect()
    {
        IsSelected = false;
        Highlight();
    }

    private void Highlight()
    {
        _background.color = IsSelected ? _higlighted : _default;
    }

    private void Fill()
    {
        _nameText.text = _item.Name;
        _costText.text = _item.Price.ToString();
        _icon.sprite = _item.Sprite;
    }

    private void SpawnPickup(Vector3 position)
    {
        Instantiate<GameObject>(_item.Pickup, position, Quaternion.identity);
    }

}
