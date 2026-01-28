using UnityEngine;

public class GlobalAudioController : MonoBehaviour
{
    private bool _isMuted = false;
    private bool _isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            _isMuted = !_isMuted;
            AudioListener.volume = _isMuted ? 0f : 1f;
            Debug.Log(_isMuted ? "Global Mute: ON" : "Global Mute: OFF");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            _isPaused = !_isPaused;
            AudioListener.pause = _isPaused;
            Debug.Log(_isPaused ? "Global Pause: ON" : "Global Pause: OFF");
        }
    }
}