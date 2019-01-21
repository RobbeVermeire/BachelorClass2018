using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningObject : MonoBehaviour {

    public float speed = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Rotate();
	}

    void Rotate()
    {
        // Rotate the object around its local X axis at 1 degree per second
        //gameObject.transform.Rotate(Vector3.right * Time.deltaTime * speed);

        // ...also rotate around the World's Y axis
        gameObject.transform.Rotate(new Vector3(0, speed, 0)* Time.deltaTime, Space.World);
    }
}
