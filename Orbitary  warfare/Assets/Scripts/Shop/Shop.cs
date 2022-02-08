using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private RuntimeRepository _playerRepo;
    [SerializeField] private EventAsset _pauseRequest;
    //[SerializeField] private EventAsset _onPlayerChange;
    [SerializeField] private Button _buyButton; // used only for enabling/disabling button object

    private ShopSlot[] _slots;
    private HashSet<ShopSlot> _selectedSlots = new HashSet<ShopSlot>();
    private Receipt _currentReceipt;
    private Bank _bank;

    private void Awake()
    {
        _slots = GetComponentsInChildren<ShopSlot>();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        foreach (var slot in _slots)
        {
            slot.OnClick += Select;
        }
        _currentReceipt = new Receipt();
        _buyButton.interactable = false;
    }

    private void Start()
    {
        _bank = _playerRepo.GetObjects()[0].GetComponent<Bank>();
    }

    private void OnDisable()
    {
        foreach (var slot in _slots)
        {
            slot.OnClick -= Select;
        }
        foreach (var selectedSlot in _selectedSlots)
        {
            selectedSlot.Unselect();
        }
    }

    public void Open()
    {
        gameObject.SetActive(true);
        _pauseRequest.Invoke((int)GamePauseRequestType.Pause);
    }

    public void BuyButtonHandler()
    {
        if (!_bank.CheckAvailable(_currentReceipt.TotalPrice)) { return; }

        BuySelected();
        _bank.Remove(_currentReceipt.TotalPrice);
        _currentReceipt = new Receipt();
    }

    private void BuySelected()
    {
        foreach (var slot in _selectedSlots)
        {
            slot.Buy(_playerRepo.GetObjects()[0].transform.position);
        }
        _selectedSlots.Clear();
        _buyButton.interactable = false;
    }

    public void CloseButtonHandler()
    {
        _pauseRequest.Invoke((int)GamePauseRequestType.UnPause);
        //_onPlayerChange.Invoke(0);
        gameObject.SetActive(false);
    }

    private void Select(ShopSlot slot)
    {
        if (slot.IsSelected)
        {
            _selectedSlots.Add(slot);
            _currentReceipt.AddValue(slot.Price);
        }
        else
        {
            _selectedSlots.Remove(slot);
            _currentReceipt.SubtractValue(slot.Price);
        }

        _buyButton.interactable = _bank.CheckAvailable(_currentReceipt.TotalPrice) 
            && _selectedSlots.Count != 0;
    }


    private struct Receipt
    {
        public int TotalPrice { get; private set; }

        public void AddValue(int value)
        {
            TotalPrice += value;
        }

        public void SubtractValue(int value)
        {
            TotalPrice -= value;
        }
    }

}
