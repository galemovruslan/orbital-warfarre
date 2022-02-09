using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AvoidBehaviour))]
public class SpaceShipAimer : EnemyAimer
{
    [SerializeField] private RuntimeRepository _playerRepo;
    protected override void Start()
    {
        OnRepositoryChange();
        _playerRepo.OnRemove += OnRepositoryChange;
        base.Start();
    }

    private void OnRepositoryChange()
    {
        _defaultTarget = _playerRepo.GetObjects()[0].transform;
    }
}
