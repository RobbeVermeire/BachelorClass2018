using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingCube : MonoBehaviour {

    //public GameObject cube;
    //float x = 0.25f;
    //Vector3 v;
    // Use this for initialization
    public GameObject cube1;
    public GameObject cube2;
	void Start () {
        // v = new Vector3(140, 5, 180);
        //cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //cube.transform.position = new Vector3(105, -100, -170);
        //cube.transform.localScale = v;
        //cube.GetComponent<Renderer>().material.color = Color.yellow;
        cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        InitCubes(50, 50, 100, 100);
    }
	
	// Update is called once per frame
	void Update () {
        //v.y += x;

	}
    public void InitCubes(int startX,int startY,int startZ, int scale)
    {
        cube1.transform.position = new Vector3(startX + 0.11533566656061f * scale, startY + 0.05902004454342f * scale, startZ); //x en y in center
        cube1.transform.localScale = new Vector3(0.112949941139039f * scale, 0.10690423162583f * scale, scale / 10);
        cube1.GetComponent<Renderer>().material.color = Color.red;

        cube2.transform.position = new Vector3(startX + 0.27943048043270f * scale, startY + 0.05902004454342f * scale, startZ);
        cube2.transform.localScale = new Vector3(0.08129175946547f * scale, 0.10690423162583f * scale, scale / 10);
        cube2.GetComponent<Renderer>().material.color = Color.yellow;
    }
}
