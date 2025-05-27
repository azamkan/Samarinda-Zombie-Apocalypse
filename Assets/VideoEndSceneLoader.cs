using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoEndSceneLoader : MonoBehaviour
{
    public string nextSceneName = "MainGameScene"; // Ganti dengan nama scene tujuan
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoEnd;

        // Pastikan video diputar dari awal
        videoPlayer.time = 0.0f;
        videoPlayer.Play();
    }

    void Update()
    {
        // Tekan tombol Space untuk skip video
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SkipVideo();
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        LoadNextScene();
    }

    public void SkipVideo()
    {
        videoPlayer.Stop(); // Opsional, berhentikan video
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
