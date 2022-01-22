using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradableVisuals : MonoBehaviour
{
    [SerializeField] private Transform _visualsTransform;

    private GameObject _currentVisuals;
    private SpriteRenderer _renderer;

    public void SetVisuals(GameObject visual)
    {
        if(_currentVisuals != null)
        {
            Destroy(_currentVisuals);
        }
        _currentVisuals = visual;

        _currentVisuals = Instantiate(_currentVisuals, _visualsTransform.position, _visualsTransform.rotation, transform);
        _currentVisuals.transform.localScale = _visualsTransform.localScale;

        _renderer = _currentVisuals.GetComponent<SpriteRenderer>();
    }

    public void Show()
    {
        if(_renderer == null) { return; }

        _renderer.enabled = true;
    }

    public void Hide()
    {
        if (_renderer == null) { return; }

        _renderer.enabled = false;
    }

    public void DestroyVisuals()
    {
        if (_currentVisuals != null)
        {
            Destroy(_currentVisuals);
        }
    }

}
