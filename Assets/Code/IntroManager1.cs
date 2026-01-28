using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class IntroManager : MonoBehaviour
{
    [Header("Settings")]
    public VideoPlayer videoPlayer;
    public AudioSource bgmSource;
    public Button skipButton;
    public string nextSceneName = "SceneA";
    public float delayBeforeVideo = 2f;

    void Start()
    {
        if (skipButton != null)
        {
            skipButton.onClick.AddListener(SkipAction);
            skipButton.gameObject.SetActive(true);
        }

        videoPlayer.loopPointReached += OnVideoFinished;
        if (bgmSource != null)
        {
            bgmSource.Play();
        }
        StartCoroutine(PlayVideoAfterAudio());
    }

    IEnumerator PlayVideoAfterAudio()
    {
        yield return new WaitForSeconds(delayBeforeVideo);

        videoPlayer.Play();
    }
    public void SkipAction()
    {
        LoadNextScene();
    }
    void OnVideoFinished(VideoPlayer vp)
    {
        LoadNextScene();
    }

    void LoadNextScene()
    {
        if (videoPlayer.isPlaying) videoPlayer.Stop();
        if (bgmSource.isPlaying) bgmSource.Stop();

        SceneManager.LoadScene(nextSceneName);
    }
}