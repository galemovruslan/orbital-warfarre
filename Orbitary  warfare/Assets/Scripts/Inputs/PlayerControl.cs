using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ShipMovement))]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private EventAsset _pauseRequest;

    private float _thrustComand = 0f;
    private float _rotateComand = 0f;

    private bool _isEnabled = true;
    private bool _fireComand = false;

    private ShipMovement _movement;
    private Shooter _shooter;

    public void Disable()
    {
        _isEnabled = false;
    }
    public void Enable()
    {
        _isEnabled = true;
    }

    private void Awake()
    {
        _movement = GetComponent<ShipMovement>();
        _shooter = GetComponent<Shooter>();

        _pauseRequest.AddListener(ProcessOnPauseEvent);
    }

    private void Update()
    {
        if (!_isEnabled) { return; }
        if (EventSystem.current.IsPointerOverGameObject()) { return; }

        MoveCommands();
        FireComands();
    }

    private void FireComands()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _fireComand = true;
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            _fireComand = false;
        }

        _shooter.Shoot(_fireComand);
    }

    private void MoveCommands()
    {
        _thrustComand = Input.GetAxis("Vertical");
        _rotateComand = Input.GetAxis("Horizontal");

        _movement.Move(_thrustComand, _rotateComand);
    }

    private void ProcessOnPauseEvent(int code)
    {
        GamePauseRequestType requsetType = (GamePauseRequestType)code;

        switch (requsetType)
        {
            case GamePauseRequestType.Pause:
                _isEnabled = false;
                break;
            case GamePauseRequestType.UnPause:
                _isEnabled = true;
                break;
        }
    }
}