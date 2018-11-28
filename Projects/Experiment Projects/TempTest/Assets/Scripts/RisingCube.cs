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
        CreateRectanlge(0, 0, 0, 1, 50, 50, 100, 100, 500, Color.yellow);
        CreateRectanlge(0, 0, 150, 1, 50, 50, 100, 100, 500, Color.red);
    }
	
	// Update is called once per frame
	void Update () {
        //v.y += x;
        //cube.transform.localScale = v;
	}
    void InitializeCubes(int startX,int startY, int startZ, float scale) // scale = width of plane
    {
        // top left of foto is 0,0
        cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube5 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube6 = GameObject.CreatePrimitive(PrimitiveType.Cube);


      /*  cube7 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube8 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube9 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube10 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube11 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube12 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube13 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube14 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube15 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube16 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube17 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube18 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube19 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube20 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube21 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube22 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube23 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube24 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube25 = GameObject.CreatePrimitive(PrimitiveType.Cube); */

       /* cube1.transform.position = new Vector3(startX + 0.11533566656061* scale, startY + 0.05902004454342* scale, startZ); //x en y in center
        cube1.transform.localScale = new Vector3(0.112949941139039 * scale, 0.10690423162583 * scale, scale / 10);
        cube.GetComponent<Renderer>().material.color = Color.red;

        cube2.transform.position = new Vector3(startX + 0.27943048043270* scale, startY + 0.05902004454342 * scale, startZ);
        cube2.transform.localScale = new Vector3(0.08129175946547 * scale, 0.10690423162583 * scale, scale / 10); */
        //cube.GetComponent<Renderer>().material.color = Color.yellow;

      /*  cube3.transform.position = new Vector3(startX, startY, startZ);
        cube4.transform.position = new Vector3(startX, startY, startZ);
        cube5.transform.position = new Vector3(startX, startY, startZ);
        cube6.transform.position = new Vector3(startX, startY, startZ);


        cube7.transform.position = new Vector3(startX, startY, startZ);
        cube8.transform.position = new Vector3(startX, startY, startZ);
        cube9.transform.position = new Vector3(startX, startY, startZ);
        cube10.transform.position = new Vector3(startX, startY, startZ);
        cube11.transform.position = new Vector3(startX, startY, startZ);
        cube12.transform.position = new Vector3(startX, startY, startZ);
        cube13.transform.position = new Vector3(startX, startY, startZ);
        cube14.transform.position = new Vector3(startX, startY, startZ);
        cube15.transform.position = new Vector3(startX, startY, startZ);
        cube16.transform.position = new Vector3(startX, startY, startZ);
        cube17.transform.position = new Vector3(startX, startY, startZ);
        cube18.transform.position = new Vector3(startX, startY, startZ);
        cube19.transform.position = new Vector3(startX, startY, startZ);
        cube20.transform.position = new Vector3(startX, startY, startZ);
        cube21.transform.position = new Vector3(startX, startY, startZ);
        cube22.transform.position = new Vector3(startX, startY, startZ);
        cube23.transform.position = new Vector3(startX, startY, startZ);
        cube24.transform.position = new Vector3(startX, startY, startZ);
        cube25.transform.position = new Vector3(startX, startY, startZ); */

    }
    public void CreateRectanlge(float startX,float startY,float startZ, float scale, float centerX, float centerZ, float width, float length, float heigth,Color color)
    {
        // y-as is naarboven
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(startX + centerX * scale, startY , startZ + centerZ * scale);
        cube.transform.localScale = new Vector3(width * scale, heigth * scale, length * scale);
        cube.GetComponent<Renderer>().material.color = color;
    }
}
