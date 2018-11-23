using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingCube : MonoBehaviour {

    public GameObject cube;
    float x = 0.25f;
    Vector3 v;
	// Use this for initialization
	void Start () {
        v = new Vector3(140, 5, 180);
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(105, -100, -170);
        cube.transform.localScale = v;
        cube.GetComponent<Renderer>().material.color = Color.yellow;
	}
	
	// Update is called once per frame
	void Update () {
        v.y += x;
        cube.transform.localScale = v;
	}
}
