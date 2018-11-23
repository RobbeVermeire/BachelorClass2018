using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour {

    public VideoPlayer VideoPlayer;

	// Use this for initialization
	void Start () {
        startTakeNumber(1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void startTakeNumber(int numberOfTake)
    {
        VideoPlayer.url = "Assets/Footage/" + numberOfTake.ToString() + ".MP4";
        VideoPlayer.Play();
    }
}
