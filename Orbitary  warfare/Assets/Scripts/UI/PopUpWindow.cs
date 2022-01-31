using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class PopUpWindow : MonoBehaviour
{
    public static PopUpWindow Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Button _yesButton;
    [SerializeField] private Button _noButton;

    private Action _yesAction;
    private Action _noAction;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        gameObject.SetActive(false);
    }

    public void Show(string text, Action yesAction, Action noAction)
    {
        gameObject.SetActive(true);

        _text.text = text;
        _yesAction = yesAction;
        _noAction = noAction;

        _yesButton.onClick.AddListener(OnYes);
        _noButton.onClick.AddListener(OnNo);
    }
    private void OnYes()
    {
        _yesAction.Invoke();
        RemoveListeners();
        Hide();
    }

    private void OnNo()
    {
        _noAction.Invoke();
        RemoveListeners();
        Hide();
    }

    private void Hide() 
    {
        gameObject.SetActive(false);
    }


    private void RemoveListeners()
    {
        _yesButton.onClick.RemoveListener(OnYes);
        _noButton.onClick.RemoveListener(OnNo);
    }

}
