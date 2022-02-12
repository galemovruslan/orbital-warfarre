using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaker : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private EventAsset _playRequest;


    private void OnEnable()
    {
        _playRequest.AddListener(PlayClip);
    }

    private void OnDisable()
    {
        _playRequest.RemoveListener(PlayClip);
    }

    public void PlayClip(int obj)
    {
        GameSoundPlayer.Instance.Play(_audioClip);
    }
}

