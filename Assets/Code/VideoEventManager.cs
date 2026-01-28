using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoEventManager : MonoBehaviour
{
    private VideoPlayer _videoPlayer;
    public GameObject endPanel;

    void Awake()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.prepareCompleted += OnVideoPrepared; // lanang ngeh 
        _videoPlayer.loopPointReached += OnVideoFinished;
    }

    void Start()
    {
        if (endPanel != null) endPanel.SetActive(false);
        _videoPlayer.Prepare();
        Debug.Log("Đang chuẩn bị video...");
    }

    void OnVideoPrepared(VideoPlayer vp)
    {
        Debug.Log("Video ready!");
        vp.Play();
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        Debug.Log("Video finished - Showing Panel");
        if (endPanel != null)
        {
            endPanel.SetActive(true);
        }
    }
}