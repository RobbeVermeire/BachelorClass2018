using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MoveToCamera : MonoBehaviour {

    //public Vector3 targetPos = new Vector3(21, 20, 16);
    public Vector3 targetPos = new Vector3(1, 2, -7);
    private Vector3 audioPos = new Vector3(1 , 5, 2);
    public float startMovingTime = 5;
    public AudioSource audioSource;
    private bool IsAtTargetPos = false;

    // Speed in units per sec.
    public float speed = 1;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {

        if (Time.time > startMovingTime)
        {
            MoveCloser();
        }

        if (gameObject.transform.position == targetPos)
        {
            IsAtTargetPos = true;
        }
        
    }

    void MoveCloser() {
        // The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;
        // Move our position a step closer to the target.
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPos, step);
        audioSource.transform.position = gameObject.transform.position;
    }
}
