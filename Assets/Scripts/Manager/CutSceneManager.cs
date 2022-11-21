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
    public int cutSceneIndex = 0;

    void Start()
    {
        imageUI.SetActive(false);
    }

    public void VideoActive()
    {
        videoPlayer.clip = videos[cutSceneIndex];
        imageUI.SetActive(true);
        videoPlayer.Play();
        videoPlayer.loopPointReached += CheckOver;
    }

    public void VideoInActive()
    {   
        videoPlayer.loopPointReached -= CheckOver;
        videoPlayer.Stop();
        imageUI.SetActive(false);
        
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("Video Is Over");
        VideoInActive();
    }
}
