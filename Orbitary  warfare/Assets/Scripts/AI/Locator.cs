using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locator : MonoBehaviour
{
    private ITargetHelper _targetHelper;

    private void Awake()
    {
        _targetHelper = GetComponentInParent<ITargetHelper>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<PlayerControl>(out var playerControl ) )
        {
            _targetHelper.SetTarget(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerControl>(out var playerControl))
        {
            _targetHelper.ResetTarget();
        }
    }

}
