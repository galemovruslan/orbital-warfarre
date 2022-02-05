using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ShopItem", fileName ="New Shop Item")]
public class ShopItem : ScriptableObject
{
    public int Price { get => _price; }
    public string Name { get => _name; }
    public Sprite Sprite { get => _sprite; }

    [SerializeField] private string _name;  
    [SerializeField] private int _price;
    [SerializeField] private Sprite _sprite;

}
