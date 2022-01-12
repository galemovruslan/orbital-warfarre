using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ITargetHelper
{
    [SerializeField] private Transform _defaultTarget;
    [SerializeField] private float _predictionTime = 0f;

    private Transform _targetPoint; // Goal for _behaviour
    private Transform _targetObject; // target's game object transform
    private ShipMovement _targetMovement;
    private AgentBehaviour _behaviour;
    private AIShooter _shooter;

    private void Awake()
    {
        _defaultTarget = new GameObject($"{name}'s default target").transform;
        _defaultTarget.position = new Vector3(transform.position.x, transform.position.y, transform.position.z) + transform.right * 10;

        _targetPoint = new GameObject("Turrent's target").transform;
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
        if (_targetObject == null) { return; }

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
