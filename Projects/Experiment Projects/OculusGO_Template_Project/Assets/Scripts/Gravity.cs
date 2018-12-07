using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

    public float floorLevel;
    public float gravity;
    private Vector3 v;
    private float time;
    private float resetTime;
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        if(gravity == 0)
        {
            gravity = 0.005f;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        if(gameObject.transform.position.y > floorLevel)
        {
            v = new Vector3(0, (float)-gravity * Mathf.Pow(Time.time-resetTime, 2), 0); // g*t^2
            gameObject.transform.position += v;
        }
        else
        {
            gameObject.transform.position = new Vector3(0, 10, 0);
            resetTime = Time.time;
        }

	}
}
