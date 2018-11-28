using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingCube : MonoBehaviour {

    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public GameObject cube4;
    public GameObject cube5;
    public GameObject cube6;
    public GameObject cube7;
    public GameObject cube8;
    public GameObject cube9;
    public GameObject cube10;
    public GameObject cube11;
    public GameObject cube12;
    public GameObject cube13;
    public GameObject cube14;
    public GameObject cube15;
    public GameObject cube16;
    public GameObject cube17;
    public GameObject cube18;
    public GameObject cube19;
    public GameObject cube20;
    public GameObject cube21;
    public GameObject cube22;
    public GameObject cube23;
    public GameObject cube24;
    public GameObject cube25;

    float x = 0.25f;
    Vector3 v;
	// Use this for initialization
	void Start () {
        /* v = new Vector3(140, 5, 180);
         cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
         cube.transform.position = new Vector3(105, -100, -170);
         cube.transform.localScale = v;
         cube.GetComponent<Renderer>().material.color = Color.yellow; */

    }
	
	// Update is called once per frame
	void Update () {
        //v.y += x;
        //cube.transform.localScale = v;
        InitializeCubes(0, 0, 0, 0.1); // 100x100

    }
    void InitializeCubes(int startX,int startY, int startZ, float scale) // scale = width of plane
    {
        cube1 = CreateRectanlge(startX, startY, startY, scale, 115.5, 59.5, 113, 107, 300, Color.red);
        cube1 = CreateRectanlge(startX, startY, startY, scale,333.5 ,59.5 , 81, 107, 400, Color.yellow);

    }
    public GameObject CreateRectanlge(float startX,float startY,float startZ, float scale, float centerX, float centerZ, float width, float length, float heigth,Color color)
    {
        //scale = 1 => 1000x1000
        // y-as is naarboven
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(startX + centerX * scale, startY , startZ + centerZ * scale);
        cube.transform.localScale = new Vector3(width * scale, heigth * scale, length * scale);
        cube.GetComponent<Renderer>().material.color = color;
        return cube;
    }
}
