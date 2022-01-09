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
    private Predictor _predictor;
    private ShipMovement _targetMovement;

    private void Awake()
    {
        _targetPoint = new GameObject("Enemy ship's target").transform;
        _targetObject = _defaultTarget;

        ShipMovement shipMovement = GetComponent<ShipMovement>();
        _predictor = new Predictor();
    }

    private void Start()
    {
        _behaviour = GetComponent<AgentBehaviour>();
        _behaviour.SetNewTarget(_targetPoint);
        ResetTarget();
    }

    private void Update()
    {
        _targetPoint.position = _targetObject.position;

        if (_targetMovement == null) { return; }

        Vector3 nextShipPosition = _predictor.Predict(_targetMovement.Position, _targetMovement.Velocity, _predictionTime);
        _targetPoint.position = nextShipPosition;

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
