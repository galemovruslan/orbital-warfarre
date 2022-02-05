using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ITargetHelper
{
    [SerializeField] protected Transform _defaultTarget;
    [SerializeField] private float _predictionTime = 0f;

    private Transform _targetPoint; // Goal for _behaviour
    private Transform _targetObject; // target's game object transform
    private ShipMovement _targetMovement;
    private AgentBehaviour _behaviour;
    private AIShooter _shooter;
    private string _parentName = "Enemy target";
    private GameObject _targetParent;

    protected virtual void Awake()
    {
        
        _targetPoint = new GameObject("Enemy's target").transform;
        _targetObject = _defaultTarget;

        _targetParent = GameObject.Find(_parentName);
        if (_targetParent == null)
        {
            _targetParent = new GameObject(_parentName);
        }
        _targetPoint.parent = _targetParent.transform;

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
