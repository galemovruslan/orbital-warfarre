using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AvoidBehaviour))]
public class SpaceShip : MonoBehaviour, ITargetHelper
{
    [SerializeField] private Transform _defaultTarget;
    [SerializeField] private float _predictionTime = 0f;

    AgentBehaviour _behaviour;
    private Transform _targetPoint; // Goal for _behaviour
    private Transform _targetObject; // target's game object transform
    private ShipMovement _targetMovement;
    private AIShooter _shooter;

    private void Awake()
    {
        _targetPoint = new GameObject("Enemy ship's target").transform;
        _targetObject = _defaultTarget;

        ShipMovement shipMovement = GetComponent<ShipMovement>();
        
        _shooter = GetComponent<AIShooter>();
    }

    private void Start()
    {
        _behaviour = GetComponent<AgentBehaviour>();
        _behaviour.SetNewTarget(_targetPoint);
        ResetTarget();
    }

    private void Update()
    {
        if(_targetObject == null) { return; }

        if (_targetMovement == null)
        {
            _targetPoint.position = _targetObject.position;
        }
        else
        {
            Vector3 nextShipPosition = Predictor.Predict(_targetMovement.Position, _targetMovement.Velocity, _predictionTime);
            _targetPoint.position = nextShipPosition;

            _shooter.TryShoot(nextShipPosition);
        }

    }

    private void OnDestroy()
    {
        if (_targetPoint != null)
        {
            Destroy(_targetPoint.gameObject);
        }
    }

    public void ResetTarget()
    {
        _targetMovement = null;
        SetTarget(_defaultTarget);
    }

    public void SetTarget(Transform newTarget)
    {
        _targetObject = newTarget;
        if (newTarget.TryGetComponent<ShipMovement>(out var movement))
        {
            _targetMovement = movement;
        }
    }
}
