using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundPlayer : MonoBehaviour
{
    public static GameSoundPlayer Instance;

    private readonly string _volumeSaveKey = "Game Volume";

    [Range(0,1)]
    [SerializeField] private float _volume = 0.5f;

    private AudioSource _audioSource;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (PlayerPrefs.HasKey(_volumeSaveKey))
        {
            _volume = PlayerPrefs.GetFloat(_volumeSaveKey);
        }
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetFloat(_volumeSaveKey, _volume);
    }

    public void Play(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip, _volume);
        Debug.Log($"playing clip: {clip.name}");
    }


}
