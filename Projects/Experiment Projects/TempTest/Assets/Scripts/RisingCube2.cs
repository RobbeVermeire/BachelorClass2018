using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingCube2 : MonoBehaviour {

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
        ColorUtility.TryParseHtmlString(hex_blue, out myBlue);
        myYellow = new Color();
        ColorUtility.TryParseHtmlString(hex_yellow, out myYellow);
        myRed = new Color();
        ColorUtility.TryParseHtmlString(hex_red, out myRed);

        cubes = new List<GameObject>();
        InitializeCamera(800, 100, 800);
        InitializePlane(0.8f);
        InitializeCubes(0.8f);
    }
	
	// Update is called once per frame
	void Update () {
        RisingCubes();
	}
    void InitializeCamera(float X, float Y, float Z)
    {
        camerRig.transform.position = new Vector3(X, Y, Z);
       // camerRig.GetComponent<Camera>().nearClipPlane = 1000f; // no camera object
    }
    GameObject CreateRectanlge(float startX, float startY, float startZ, float X, float Y, float Z, float width, float length, Color color, float scale = 1, float heigth = 1 )
    {
        // X,Y,Z gemeten in linker bovenhoek
        // startX and startZ => top left corner of rectangle around circle (200x200)
        // functie zo opgesteld dat je de waardes gemeten in GIMP gewoon kan overpakken
        // conversie van assenstelsel gebeurd hier
        var circla_dia = 200;
        X = X + width / 2;
        Z = Z + length / 2;
        Y = heigth / 2;
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(startX - (X * scale), startY + Y*scale , startZ + Z  * scale);
        cube.transform.localScale = new Vector3(width * scale, heigth * scale, length * scale);
        cube.GetComponent<Renderer>().material.color = color;
        cubes.Add(cube);// add to list
        return cube;
    }
    void InitializeCubes( float scale = 1,float startX=2000, float startY=0, float startZ=0) // scale = width of plane
    {
        startX *= scale;
        //starX/startZ -> linksebovenhoek
        // CreateRectanlge(startX, startY, startZ, x, y, z, width, legnth, color,scale);
        CreateRectanlge(startX, startY, startZ,763 ,1 ,73,85 ,130 ,myRed,scale); //1
        CreateRectanlge(startX, startY, startZ,853 ,1 ,73 ,245 ,95,myBlue, scale); //2
        CreateRectanlge(startX, startY, startZ,357 ,1 ,302 ,64 ,57,myYellow, scale); //3
        CreateRectanlge(startX, startY, startZ,426,1,301,221,58,myBlue,scale); //4
        CreateRectanlge(startX, startY, startZ,853,1,301,245,121,myRed, scale); //5
        CreateRectanlge(startX, startY, startZ,1216,1,173,148,204,myYellow, scale); //6
        CreateRectanlge(startX, startY, startZ,651,1,427,85,112,myYellow, scale); //7
        CreateRectanlge(startX, startY, startZ,1369,1,382,56,136,myRed, scale); //8
        CreateRectanlge(startX, startY, startZ,357,1,543,64,210,myRed, scale); //9
        CreateRectanlge(startX, startY, startZ,562,1,543,174,150,myBlue, scale);
        CreateRectanlge(startX, startY, startZ,853,1,523,108,16,myYellow, scale);
        CreateRectanlge(startX, startY, startZ,1216,1,523,148,118,myBlue, scale);
        CreateRectanlge(startX, startY, startZ,1500,1,460,208,181,myBlue, scale);
        CreateRectanlge(startX, startY, startZ,426,1,758,131,58,myYellow, scale);
        CreateRectanlge(startX, startY, startZ,741,1,821,107,80,myRed, scale);
        CreateRectanlge(startX, startY, startZ,853,1,646,108,170,myYellow, scale);
        CreateRectanlge(startX, startY, startZ,1104,1,646,107,255,myRed, scale);
        CreateRectanlge(startX, startY, startZ,1216,1,646,148,75,myYellow, scale);
        CreateRectanlge(startX, startY, startZ,1500,1,683,54,103,myYellow, scale);
        CreateRectanlge(startX, startY, startZ,1713,1,791,89,160,myYellow, scale);
        CreateRectanlge(startX, startY, startZ,853,1,906,108,55,myYellow, scale);
        CreateRectanlge(startX, startY, startZ,209,1,966,174,153,myBlue, scale);
        CreateRectanlge(startX, startY, startZ,741,1,966,107,153,myBlue, scale);
        CreateRectanlge(startX, startY, startZ,966,1,966,69,69,myRed, scale,1);
        CreateRectanlge(startX, startY, startZ,1141,1,966,70,70,myBlue, scale);
        CreateRectanlge(startX, startY, startZ,1369,1,1039,185,80,myRed, scale);
        CreateRectanlge(startX, startY, startZ,1559,1,956,198,163,myBlue, scale);
        CreateRectanlge(startX, startY, startZ,1559,1,1124,72,137,myYellow, scale);
        CreateRectanlge(startX, startY, startZ,1216,1,1209,148,109,myBlue, scale);
        CreateRectanlge(startX, startY, startZ,966,1,1124,170,81,myYellow, scale);
        CreateRectanlge(startX, startY, startZ,562,1,1123,286,151,myRed, scale);
        CreateRectanlge(startX, startY, startZ,334,1,1201,223,162,myYellow, scale);
        CreateRectanlge(startX, startY, startZ,334,1,1368,107,174,myRed, scale);
        CreateRectanlge(startX, startY, startZ,666,1,1368,67,174,myBlue, scale);
        CreateRectanlge(startX, startY, startZ,853,1,1279,108,84,myBlue, scale);
        CreateRectanlge(startX, startY, startZ,853,1,1368,108,60,myYellow, scale);
        CreateRectanlge(startX, startY, startZ,1141,1,1368,70,119,myRed, scale);
        CreateRectanlge(startX, startY, startZ,1216,1,1368,148,174,myRed, scale);
        CreateRectanlge(startX, startY, startZ,1534,1,1427,97,207,myRed, scale);
        CreateRectanlge(startX, startY, startZ,1141,1,1639,223,87,myYellow, scale);
        CreateRectanlge(startX, startY, startZ,891,1,1731,70,44,myYellow, scale);
        CreateRectanlge(startX, startY, startZ,738,1,1547,148,179,myRed, scale);
        CreateRectanlge(startX, startY, startZ,619,1,1547,114,63,myYellow, scale);
        CreateRectanlge(startX, startY, startZ,200,1,1547,129,125,myBlue, scale);

    }
    GameObject InitializePlane(float scale = 1 ,float posX = 1000, float posY=0, float posZ=1000, float height = 0.1f)
    {
        var length = 200;
        var width = 200;
        posX *= scale;
        posZ *= scale;
        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(imageAsset.bytes); // loadimage to texture
        plane = GameObject.CreatePrimitive(PrimitiveType.Plane); // create plane object
        Renderer renderer = plane.GetComponent<Renderer>(); // get renderer
        renderer.material.mainTexture = texture; // assing texture
        plane.transform.position = new Vector3(posX , posY, posZ); // position
        plane.transform.localScale = new Vector3(width * scale, height, length * scale); // resize
        return plane;
    }
    void RisingCubes()
    {
        if (!ready)
        {
            teller += 1;
            Debug.Log("Teller: " + teller);
            if (teller == 300)
            {
                ready = true;
                cubes.RemoveAt(23);// remove starting cube
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
}
