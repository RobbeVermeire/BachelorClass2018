using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SphereController : MonoBehaviour
{
    private bool paused = false;
    public VideoPlayer VideoPlayer;
    // Use this for initialization
    void Start()
    {
        VideoPlayer.Prepare();
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(VideoPlayer.time);
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            if (!paused)
            {
                VideoPlayer.Pause();
                paused = true;              
            }
            else
            {
                VideoPlayer.Play();
                paused = false;
            }

        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            VideoPlayer.frame += 5;
            VideoPlayer.Play();
            VideoPlayer.Pause();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            VideoPlayer.frame -= 100;
            VideoPlayer.Play();
            VideoPlayer.Pause();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameObject.transform.position += new Vector3(0, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gameObject.transform.position -= new Vector3(0, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameObject.transform.Rotate(new Vector3(0, -1, 0), Space.World);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gameObject.transform.Rotate(new Vector3(0, 1, 0), Space.World);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            VideoPlayer.Stop();
            VideoPlayer.Play();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            gameObject.transform.localScale += new Vector3(2, 2, 2);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            gameObject.transform.localScale -= new Vector3(2, 2, 2);
        }

    }

}
