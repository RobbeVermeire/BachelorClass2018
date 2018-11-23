using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour {

    public VideoPlayer VideoPlayer;
    public Vector3 Vright,Vleft;
    public int frame;
	// Use this for initialization
	void Start () {
        StartVideo("2"); 
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void StartVideo(string videoName)
    {
        VideoPlayer.url = "Assets/Footage/" + videoName + ".MP4";
        VideoPlayer.Play();
    }

    private void SetFilm(bool direction)
    {
        //GameObject g = GameObject.Find("[CameraRig]");
        
    }
}
