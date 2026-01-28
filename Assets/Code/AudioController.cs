using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _audioSource.Play();
            Debug.Log("Âm thanh bắt đầu phát!");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _audioSource.Pause();
            Debug.Log("Đã dừng âm thanh.");
        }
    }
}
