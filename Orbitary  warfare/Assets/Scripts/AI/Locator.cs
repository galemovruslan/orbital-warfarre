using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locator : MonoBehaviour
{
    private ITargetHelper _agentBehavoiur;

    private void Awake()
    {
        _agentBehavoiur = GetComponentInParent<ITargetHelper>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<PlayerControl>(out var playerControl ) )
        {
            _agentBehavoiur.SetTarget(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerControl>(out var playerControl))
        {
            _agentBehavoiur.ResetTarget();
        }
    }

}
