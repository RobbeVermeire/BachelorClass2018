using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour {

    public VideoPlayer VideoPlayer;

    // Use this for initialization
    void Start()
    {
        VideoPlayer = GameObject.Find("Video Player").GetComponent<VideoPlayer>() as VideoPlayer;
        PlayVideoByName(VideoPlayer, "GreenScreenTest");
    }

    // Update is called once per frame
    void Update()
    {
        for(int i =0; i<100; i++)
        {

        }
        Debug.Log(VideoPlayer.isPlaying);
    }

    void PlayVideoByName(VideoPlayer _videoPlayer, string _nameOfVideo)
    {
        _videoPlayer.url = "Assets/Footage/" + _nameOfVideo + ".MP4";
        _videoPlayer.Play();
    }
    

}
