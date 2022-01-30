using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToRepository : MonoBehaviour
{
    [SerializeField] private RuntimeRepository _repository;

    private void OnEnable()
    {
        if(_repository != null)
        {
            _repository.AddObject(this.gameObject);
        }
    }

    private void OnDisable()
    {
        if (_repository != null)
        {
            _repository.RemoveObject(this.gameObject);
        }
    }
}
