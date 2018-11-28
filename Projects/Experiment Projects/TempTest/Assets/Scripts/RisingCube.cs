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

    private List<GameObject> cubes;

    public TextAsset imageAsset;
    public GameObject plane;

    public GameObject camerRig;

    float speed = 0.10f;
    bool ready = false;
    int teller = 0;
	// Use this for initialization
	void Start () {
        /* v = new Vector3(140, 5, 180);
         cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
         cube.transform.position = new Vector3(105, -100, -170);
         cube.transform.localScale = v;
         cube.GetComponent<Renderer>().material.color = Color.yellow; */
        //map = GameObject.Find("Map").GetComponent<Plane>();
        cubes = new List<GameObject>();
        InitializeCamera(1f);
        InitializeCubes(0, 0, 0, 1f); // 100x100
        InitializePlane(50,0,50,100,100,1,1);
    }
	
	// Update is called once per frame
	void Update () {
        //v.y += x;
        //cube.transform.localScale = v
        if (!ready)
        {
            teller += 1;
            Debug.Log("Teller: " + teller);
            if (teller == 300)
            {
                ready = true;
            }
        }
        else
        {
            foreach (GameObject c in cubes) // posy +=1 => height += 2
            {
                var maxHeight = 70 * Mathf.Pow((Vector3.Distance(c.transform.position, camerRig.transform.position) / 200), 2); // f(x) = 50.(x/200)^2
                if (c.transform.localScale.y < maxHeight)
                {
                    c.transform.position += new Vector3(0, speed, 0);
                    c.transform.localScale += new Vector3(0, 2 * speed, 0);
                }
            }
        }

    }

    void InitializeCamera(float scale)
    {
        //camerRig = GameObject.Find("[VRSimulator_CameraRig]").GetComponent<Camera>();
        camerRig.transform.position = new Vector3(680*scale, 60*scale, 550*scale);
        //GetComponentInChildren<Camera>().transform.position = new Vector3(680, 100, 600);
    }
    void InitializePlane(float posX, float posY, float posZ, float width, float length, float height,float scale)
    {
        posX *= 10;
        posY *= 10;
        posZ *= 10;
        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(imageAsset.bytes);
        plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        Renderer renderer = plane.GetComponent<Renderer>();
        renderer.material.mainTexture = texture;
        plane.transform.position = new Vector3(posX * scale, posY * scale, posZ * scale);
        plane.transform.localScale = new Vector3(width * scale, height, length * scale);

    }
    void InitializeCubes(float startX,float startY, float startZ, float scale) // scale = width of plane
    {
        cube1 = CreateRectanlge(startX, startY, startY, scale, 115.5f, 1, 59.5f, 113, 107, 400, Color.red);
        cube2 = CreateRectanlge(startX, startY, startY, scale,279.5f, 1, 59.5f , 81, 107, 400, Color.yellow);
        cube3 = CreateRectanlge(startX, startY, startY, scale,500, 1, 121 ,54 ,64 ,400 , Color.blue);
        cube4 = CreateRectanlge(startX, startY, startY, scale, 741, 1, 120.5f, 64, 65, 400, Color.yellow);

        cube5 = CreateRectanlge(startX, startY, startY, scale, 30, 1, 286, 48, 100, 400, Color.blue);
        cube6 = CreateRectanlge(startX, startY, startY, scale, 115.5f, 1, 286, 113, 100, 400, Color.blue);
        cube7 = CreateRectanlge(startX, startY, startY, scale, 258, 1, 330, 38, 188, 400, Color.red);
        cube8 = CreateRectanlge(startX, startY, startY, scale, 397, 1, 330.5f, 142, 189, 400, Color.yellow);
        cube9 = CreateRectanlge(startX, startY, startY, scale, 575.5f, 1, 285, 87, 98, 400, Color.red);
        cube10 = CreateRectanlge(startX, startY, startY, scale, 698.5f, 1, 382, 149, 84, 400, Color.blue);
        cube11 = CreateRectanlge(startX, startY, startY, scale, 891.5f, 1, 285, 77, 98, 400, Color.red);

        cube12 = CreateRectanlge(startX, startY, startY, scale, 58, 1, 478, 106, 98, 400, Color.yellow);
        cube13 = CreateRectanlge(startX, startY, startY, scale, 216, 1, 548.5f, 36, 33, 400, Color.red);
        cube14 = CreateRectanlge(startX, startY, startY, scale, 500, 1, 500, 54, 54, 400, Color.red);
        cube15 = CreateRectanlge(startX, startY, startY, scale, 924, 1, 448.5f, 142, 39, 400, Color.blue);

        cube16 = CreateRectanlge(startX, startY, startY, scale, 22.5f, 1, 629.5f, 35, 121, 400, Color.blue);
        cube17 = CreateRectanlge(startX, startY, startY, scale, 279.5f, 1, 630, 83, 122, 400, Color.yellow);
        cube18 = CreateRectanlge(startX, startY, startY, scale, 500, 1, 598.5f, 54, 59, 400, Color.yellow);
        cube19 = CreateRectanlge(startX, startY, startY, scale, 924, 1, 589.5f, 142, 77, 400, Color.yellow);

        cube20 = CreateRectanlge(startX, startY, startY, scale, 195.5f, 1, 825, 77, 78, 400, Color.red);
        cube21 = CreateRectanlge(startX, startY, startY, scale, 426.5f, 1, 779, 201, 168, 400, Color.blue);
        cube22 = CreateRectanlge(startX, startY, startY, scale, 698.5f, 1, 706.5f, 149, 149, 400, Color.red);
        cube23 = CreateRectanlge(startX, startY, startY, scale, 924, 1, 707, 142, 148, 400, Color.blue);

        cube24 = CreateRectanlge(startX, startY, startY, scale, 575.5f, 1, 962, 87, 66, 400, Color.blue);
        cube25 = CreateRectanlge(startX, startY, startY, scale, 947,1, 962, 96, 66, 400, Color.red);
    }
    public GameObject CreateRectanlge(float startX,float startY,float startZ, float scale, float centerX,float centerY, float centerZ, float width, float length, float heigth,Color color)
    {
        //scale = 1 => 1000x1000
        // y-as is naarboven
        heigth = 0.5f;
        centerY = heigth / 2;
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(startX + centerX * scale, startY+ centerY*scale , startZ + centerZ * scale);
        cube.transform.localScale = new Vector3(width * scale, heigth * scale, length * scale);
        cube.GetComponent<Renderer>().material.color = color;
        cubes.Add(cube);// add to list
        return cube;
    }
}
