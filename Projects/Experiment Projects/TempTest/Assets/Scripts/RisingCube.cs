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
        InitializeCubes(0, 0, 0, 0.1f); // 100x100
    }
	
	// Update is called once per frame
	void Update () {
        //v.y += x;
        //cube.transform.localScale = v;
        

    }
    void InitializeCubes(float startX,float startY, float startZ, float scale) // scale = width of plane
    {
        cube1 = CreateRectanlge(startX, startY, startY, scale, 115.5f, 59.5f, 113, 107, 400, Color.red);
        cube2 = CreateRectanlge(startX, startY, startY, scale,279.5f ,59.5f , 81, 107, 400, Color.yellow);
        cube3 = CreateRectanlge(startX, startY, startY, scale,500 ,121 ,54 ,64 ,400 , Color.blue);
        cube4 = CreateRectanlge(startX, startY, startY, scale, 741, 109, 64, 65, 400, Color.yellow);

        cube5 = CreateRectanlge(startX, startY, startY, scale, 30, 286, 48, 100, 400, Color.blue);
        cube6 = CreateRectanlge(startX, startY, startY, scale, 115.5f, 286, 113, 100, 400, Color.blue);
        cube7 = CreateRectanlge(startX, startY, startY, scale, 258, 330, 38, 188, 400, Color.red);
        cube8 = CreateRectanlge(startX, startY, startY, scale, 397, 330.5f, 142, 189, 400, Color.yellow);
        cube9 = CreateRectanlge(startX, startY, startY, scale, 575.5f, 285, 87, 98, 400, Color.red);
        cube10 = CreateRectanlge(startX, startY, startY, scale, 698.5f, 382, 149, 84, 400, Color.blue);
        cube11 = CreateRectanlge(startX, startY, startY, scale, 891.5f, 285, 77, 98, 400, Color.red);

        cube12 = CreateRectanlge(startX, startY, startY, scale, 58, 478, 106, 98, 400, Color.yellow);
        cube13 = CreateRectanlge(startX, startY, startY, scale, 216, 548.5f, 36, 33, 400, Color.red);
        cube14 = CreateRectanlge(startX, startY, startY, scale, 500, 500, 54, 54, 400, Color.red);
        cube15 = CreateRectanlge(startX, startY, startY, scale, 924, 448.5f, 142, 39, 400, Color.blue);

        cube16 = CreateRectanlge(startX, startY, startY, scale, 22.5, 629.5, 35, 121, 400, Color.blue);
        cube17 = CreateRectanlge(startX, startY, startY, scale, 279.5f, 630, 83, 122, 400, Color.yellow);
        cube18 = CreateRectanlge(startX, startY, startY, scale, 500, 598.5f, 54, 59, 400, Color.yellow);
        cube19 = CreateRectanlge(startX, startY, startY, scale, 924, 589.5f, 142, 77, 400, Color.yellow);

        cube20 = CreateRectanlge(startX, startY, startY, scale, 195.5f, 825, 77, 78, 400, Color.red);
        cube21 = CreateRectanlge(startX, startY, startY, scale, 426.5f, 779, 201, 168, 400, Color.blue);
        cube22 = CreateRectanlge(startX, startY, startY, scale, 698.5f, 706.5f, 149, 149, 400, Color.red);
        cube23 = CreateRectanlge(startX, startY, startY, scale, 924, 707, 142, 148, 400, Color.blue);

        cube24 = CreateRectanlge(startX, startY, startY, scale, 575.5f, 962, 87, 66, 400, Color.blue);
        cube25 = CreateRectanlge(startX, startY, startY, scale, 947, 962, 96, 66, 400, Color.red);
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
