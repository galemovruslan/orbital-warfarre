using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradableVisuals : MonoBehaviour
{
    [SerializeField] private Transform _visualsTransform;

    private GameObject _currentVisuals;
    
    public void SetVisuals(GameObject visual)
    {
        if(_currentVisuals != null)
        {
            Destroy(_currentVisuals);
        }
        _currentVisuals = visual;

        _currentVisuals = Instantiate(_currentVisuals, _visualsTransform.position, _visualsTransform.rotation, transform);
        _currentVisuals.transform.localScale = _visualsTransform.localScale;

    }

    public void HideVisuals()
    {
        if (_currentVisuals != null)
        {
            Destroy(_currentVisuals);
        }
    }

}
