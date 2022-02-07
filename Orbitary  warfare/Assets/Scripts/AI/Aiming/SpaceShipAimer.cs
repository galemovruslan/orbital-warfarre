using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AvoidBehaviour))]
public class SpaceShipAimer : EnemyAimer
{
    [SerializeField] private RuntimeRepository _playerRepo;
    protected override void Start()
    {
        _defaultTarget = _playerRepo.GetObjects()[0].transform;
        base.Start();
    }
}
