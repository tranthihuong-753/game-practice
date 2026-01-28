using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    private VideoPlayer _videoPlayer;

    void Awake()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (!_videoPlayer.isPlaying)
            {
                _videoPlayer.Play();
                Debug.Log("Video bắt đầu chạy!");
            }
            else
            {
                _videoPlayer.Pause();
                Debug.Log("Video tạm dừng.");
            }
        }
    }
}