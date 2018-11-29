using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingCube : MonoBehaviour {

    public List<GameObject> cubes;
    public TextAsset imageAsset;
    public GameObject plane;
    public GameObject camerRig;

    private string hex_blue = "#26348b";
    private Color myBlue;

    private string hex_yellow = "#ffdd0e";
    private Color myYellow;

    private string hex_red = "#e30613";
    private Color myRed;


    float speed = 0.10f;
    bool ready = false;
    int teller = 0;

	// Use this for initialization
	void Start () {
        myBlue = new Color();
        ColorUtility.TryParseHtmlString(hex_blue,out myBlue);
        myYellow = new Color();
        ColorUtility.TryParseHtmlString(hex_yellow, out myYellow);
        myRed = new Color();
        ColorUtility.TryParseHtmlString(hex_red, out myRed);

        cubes = new List<GameObject>();
        InitializeCamera(1000,70,1000);
        InitializeCubes(0, 0, 0, 1f, 180);// 1000x1000
        InitializeCubes(1000 - 5, 0, 0, 1f, 90);// move 5 to the right to override first plane's black sideline
        InitializeCubes(0, 0 ,1000-5, 1f, 180);//move 5 up
        InitializeCubes(1000 - 5, 0, 1000 - 5, 1f, 270);

        InitializePlane(500, 0, 500, 1, 1, 180);
        InitializePlane(1500 - 5, 0, 500, 1, 1, 90); // move 5 to the right to override first plane's black sideline
        InitializePlane(500, 0, 1500 - 5, 1, 1, 180);
        InitializePlane(1500 - 5, 0, 1500 - 5, 1, 1, 270);
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

    void InitializeCamera(float X,float Y, float Z)
    {
        camerRig.transform.position = new Vector3(X, Y, Z);
    }
    GameObject InitializePlane(float posX, float posY, float posZ,float height,float scale,float rotation)
    {
        var length = 100;
        var width = 100;

        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(imageAsset.bytes); // loadimage to texture
        plane = GameObject.CreatePrimitive(PrimitiveType.Plane); // create plane object
        Renderer renderer = plane.GetComponent<Renderer>(); // get renderer
        renderer.material.mainTexture = texture; // assing texture
        plane.transform.position = new Vector3(posX * scale, posY * scale, posZ * scale); // position
        plane.transform.localScale = new Vector3(width * scale, height, length * scale); // resize
        plane.transform.Rotate(new Vector3(0, rotation, 0), Space.World); // rotate
        return plane;
    }
    void InitializeCubes(float startX,float startY, float startZ, float scale,float rotation) // scale = width of plane
    {
        //starX/startZ -> linksebovenhoek
        CreateRectanlge(startX, startY, startZ, scale, 115.5f, 1, 59.5f, 113, 107, 400, myRed, rotation);
        CreateRectanlge(startX, startY, startZ, scale,279.5f, 1, 59.5f , 81, 107, 400, myYellow, rotation);
        CreateRectanlge(startX, startY, startZ, scale,500, 1, 121 ,54 ,64 ,400 , myBlue, rotation);
        CreateRectanlge(startX, startY, startZ, scale, 741, 1, 120.5f, 64, 65, 400, myYellow, rotation);

        CreateRectanlge(startX, startY, startZ, scale, 30, 1, 286, 48, 100, 400, myBlue, rotation);
        CreateRectanlge(startX, startY, startZ, scale, 115.5f, 1, 286, 113, 100, 400, myBlue, rotation);
        CreateRectanlge(startX, startY, startZ, scale, 258, 1, 330, 38, 188, 400, myRed, rotation);
        CreateRectanlge(startX, startY, startZ, scale, 397, 1, 330.5f, 142, 189, 400, myYellow, rotation);
        CreateRectanlge(startX, startY, startZ, scale, 575.5f, 1, 285, 87, 98, 400, myRed, rotation);
        CreateRectanlge(startX, startY, startZ, scale, 698.5f, 1, 382, 149, 84, 400, myBlue, rotation);
        CreateRectanlge(startX, startY, startZ, scale, 891.5f, 1, 285, 77, 98, 400, myRed, rotation);

        CreateRectanlge(startX, startY, startZ, scale, 58, 1, 478, 106, 98, 400, myYellow, rotation);
        CreateRectanlge(startX, startY, startZ, scale, 216, 1, 548.5f, 36, 33, 400, myRed, rotation);
        CreateRectanlge(startX, startY, startZ, scale, 500, 1, 500, 54, 54, 400, myRed, rotation);
        CreateRectanlge(startX, startY, startZ, scale, 924, 1, 448.5f, 142, 39, 400, myBlue, rotation);

        CreateRectanlge(startX, startY, startZ, scale, 22.5f, 1, 629.5f, 35, 121, 400, myBlue, rotation);
        CreateRectanlge(startX, startY, startZ, scale, 279.5f, 1, 630, 83, 122, 400, myYellow, rotation);
        CreateRectanlge(startX, startY, startZ, scale, 500, 1, 598.5f, 54, 59, 400, myYellow, rotation);
        CreateRectanlge(startX, startY, startZ, scale, 924, 1, 589.5f, 142, 77, 400, myYellow, rotation);

        CreateRectanlge(startX, startY, startZ, scale, 195.5f, 1, 825, 77, 78, 400, myRed, rotation);
        CreateRectanlge(startX, startY, startZ, scale, 426.5f, 1, 779, 201, 168, 400, myBlue, rotation);
        CreateRectanlge(startX, startY, startZ, scale, 698.5f, 1, 706.5f, 149, 149, 400, myRed, rotation);
        CreateRectanlge(startX, startY, startZ, scale, 924, 1, 707, 142, 148, 400, myBlue, rotation);

        CreateRectanlge(startX, startY, startZ, scale, 575.5f, 1, 962, 87, 66, 400, myBlue, rotation);
        CreateRectanlge(startX, startY, startZ, scale, 947,1, 962, 96, 66, 400, myRed, rotation);
    }
    public GameObject CreateRectanlge(float startX,float startY,float startZ, float scale, float centerX,float centerY, float centerZ, float width, float length, float heigth,Color color,float rotation = 0f)
    {
        //scale = 1 => 1000x1000
        
        if(rotation != 0f) // check for rotation and adjust postition and rotation if necessary
        {
            //initialize variables
            float newCenterX = 0;
            float newCenterZ = 0;
            float newWidth = 0;
            float newLength = 0;
            
            if(rotation == 270)
            {
                newCenterX = (1000 * scale) - centerZ;
                newCenterZ = centerX;
                newWidth = length;
                newLength = width;
            }
            else if(rotation == 90)
            {
                newCenterX = centerZ;
                newCenterZ = (1000 * scale) - centerX;
                newWidth = length;
                newLength = width;
            }
            else if(rotation == 180)
            {
                newCenterX = (1000 * scale) - centerX;
                newCenterZ = (1000 * scale) - centerZ;
                newWidth = width;
                newLength = length;
            }
            centerX = newCenterX;
            centerZ = newCenterZ;
            width = newWidth;
            length = newLength;
        }
        
        heigth = 200f;
        centerY = heigth / 2;
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(startX + centerX * scale, startY+ centerY*scale , startZ + centerZ * scale);
        cube.transform.localScale = new Vector3(width * scale, heigth * scale, length * scale);
        cube.GetComponent<Renderer>().material.color = color;
        cubes.Add(cube);// add to list
        return cube;
    }
    
}
