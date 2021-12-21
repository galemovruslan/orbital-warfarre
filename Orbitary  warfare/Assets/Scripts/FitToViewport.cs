using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitToViewport : MonoBehaviour
{
    Camera _mainCamera;
    RectTransform _rectTransform;

    private void Awake()
    {
        _mainCamera = Camera.main;
        _rectTransform = GetComponent<RectTransform>();

        float heightUnits = 2 * _mainCamera.orthographicSize;
        float aspectRatio = _rectTransform.rect.width / _rectTransform.rect.height;

        _rectTransform.localScale = new Vector3(
            heightUnits / _rectTransform.rect.width * aspectRatio, 
            heightUnits / _rectTransform.rect.height,
            1);

    }
}
