using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutSceneManager : MonoBehaviour
{
    [SerializeField]
    VideoClip[] videos;
    [SerializeField]
    VideoPlayer videoPlayer;
    [SerializeField]
    GameObject imageUI;
    public float[] speed;

    void Start()
    {

    }

    public void VideoActive(int idx)
    {
        videoPlayer.clip = videos[idx];
        videoPlayer.playbackSpeed = speed[idx];
        imageUI.SetActive(true);
        videoPlayer.Play();
        videoPlayer.loopPointReached += CheckOver;
    }

    public void VideoInActive()
    {   
        videoPlayer.loopPointReached -= CheckOver;
        videoPlayer.Stop();
        imageUI.SetActive(false);
        Time.timeScale = 1f;
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        VideoInActive();
        GameManager.Instance.questManager.CheckQuest();
    }
}
