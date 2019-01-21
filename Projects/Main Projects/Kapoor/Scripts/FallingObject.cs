using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour {

    public float startFallingTime = 0;
    public AudioSource audioSource;
    public CameraShake cameraShake;

    private float gravity = 0.01f;
    private Vector3 acceleration;
    private Vector3 groundPos;
    private Vector3 startPos;
    private float time;
    private bool CollisionSoundPlayed = false;

    // Use this for initialization
    void Start()
    {
        /*if (gravity == 0)
        {
            gravity = 0.1f;
        }*/

        //set start position for object
        groundPos = gameObject.transform.position;
        startPos = gameObject.transform.position;
        startPos.y = 250;
        gameObject.transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > startFallingTime)
        {
            if (gameObject.transform.position.y > groundPos.y)
            {
                FallDown();
            }
            else
            {
                ImpactGround();
            }
        }
        

    }

    void FallDown()
    {
        if (acceleration.y > -1)
        {
            acceleration = new Vector3(0, (float)-gravity * Mathf.Pow(Time.time - startFallingTime, 2), 0); // g*t^2

        }
        else
        {
            acceleration = new Vector3(0, (float)-1, 0);
        }
        gameObject.transform.position += acceleration;

        
    }

    void ImpactGround()
    {
        if (CollisionSoundPlayed == false)
        {
            audioSource.transform.position = groundPos;
            audioSource.Play();
            gameObject.transform.position = groundPos;
            gravity = 0;
            CollisionSoundPlayed = true;
            StartCoroutine(cameraShake.Shake(.30f, .4f));
        }
        else
        {

        }
    }
}
