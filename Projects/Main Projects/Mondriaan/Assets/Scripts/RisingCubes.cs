using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingCubes : MonoBehaviour
{

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

    public float Scale;

    private float TimeSinceStart;
    private bool go1;
    private bool go2;
    private bool goall;

    float cameraPos;
    // Use this for initialization
    void Start()
    {

        myBlue = new Color();
        ColorUtility.TryParseHtmlString(hex_blue, out myBlue);
        myYellow = new Color();
        ColorUtility.TryParseHtmlString(hex_yellow, out myYellow);
        myRed = new Color();
        ColorUtility.TryParseHtmlString(hex_red, out myRed);

        cubes = new List<GameObject>();
        Scale = 1f;

        camerRig.transform.position = new Vector3(1000, 140, 1000);

        InitializePlane(Scale);
        InitializeCubes(Scale);

    }

    // Update is called once per frame
    void Update()
    {
        cameraPos = camerRig.transform.rotation.eulerAngles.y;
        TimeSinceStart = Time.realtimeSinceStartup;
        RiseCubes(0.3f);
    }

    bool RiseCube(int cube, float height, float speed, bool start = false, float startTime = 0f)
    {
        startTime += 10f;

        Vector3 scale = new Vector3(0, 0, 0);
        Vector3 position = new Vector3(0, 0, 0);
        if (scale.y == 0)
        {
            scale.y = speed;
        }
        if (position.y == 0)
        {
            position.y = speed / 2;
        }
        cube--; // index
        if (cubes[cube].transform.localScale.y < height && startTime <= TimeSinceStart && start)
        {
            cubes[cube].transform.localScale += scale;
            cubes[cube].transform.position += position;
            return false;
        }
        if (cubes[cube].transform.localScale.y >= height)
        {
            return true;
        }
        return false;
    }
    void RiseCubes(float speed) // 0.3f
    {
        RiseCube(21, 70, speed, goall, 50);
        RiseCube(25, 70, speed, goall, 36);
        RiseCube(30, 70, speed, goall, 39);
        RiseCube(23, 70, speed, goall, 40);

        RiseCube(15, 130, speed, goall, 43);
        RiseCube(16, 100, speed, goall, 50);
        RiseCube(17, 100, speed, goall, 42);
        go2 = RiseCube(26, 100, speed, go1);
        RiseCube(29, 100, speed, goall, 45);


        var startTime = 9999.0f;
        if (cameraPos > 200 && cameraPos < 250 && Time.realtimeSinceStartup >= 53.5f)//not 50°
        {
            startTime = 0f;
        }
        RiseCube(31, 100, 100, goall, startTime); //  wehn not looking

        RiseCube(10, 140, speed, goall, 47);
        RiseCube(11, 120, speed, goall, 45);
        RiseCube(12, 120 + 15, speed, goall);
        go1 = RiseCube(18, 120, speed, true); // 1
        RiseCube(27, 120 + 15, speed, goall);
        RiseCube(28, 120, speed, goall, 39);
        RiseCube(35, 120, speed, goall, 38);
        RiseCube(32, 120, speed, goall, 40);

        RiseCube(1, 180 + 60, speed, goall, 22);
        RiseCube(2, 180 + 40, speed, goall, 26);
        RiseCube(3, 180 + 60, speed, goall, 28);
        RiseCube(4, 180 + 20, speed, goall, 30);
        RiseCube(5, 180 + 10, speed, goall, 35);
        RiseCube(6, 180 + 50, speed, goall, 33);
        RiseCube(7, 180 + 60, speed, goall, 28);
        RiseCube(8, 180 + 20, speed, goall, 22);
        RiseCube(9, 180 + 30, speed, goall, 30);
        RiseCube(13, 180 + 40, speed, goall, 30);
        RiseCube(14, 180 + 0, speed, goall, 28);
        RiseCube(19, 180 + 40, speed, goall, 29);
        RiseCube(20, 180 + 50, speed, goall, 38);
        goall = RiseCube(22, 180 + 0, speed, go2);
        //RiseCube(24, 180 + Random.Range(0, 50), 0.1f); center cube
        RiseCube(33, 180 + 5, speed, goall, 28);
        RiseCube(34, 180 + 30, speed, goall, 22);
        RiseCube(36, 180 + 15, speed, goall, 24);
        RiseCube(37, 180 + 10, speed, goall, 36);
        RiseCube(38, 180 + 10, speed, goall, 26);
        RiseCube(39, 180 + 80, speed, goall, 32);
        RiseCube(40, 180 + 20, speed, goall, 22);
        RiseCube(41, 180 + 5, speed, goall, 34);
        RiseCube(42, 180 + 40, speed, goall, 34);
        RiseCube(43, 180 + 60, speed, goall, 32);
        RiseCube(44, 180 + 40, speed, goall, 26);
    }
    GameObject CreateRectanlge(float startX, float startY, float startZ, float X, float Y, float Z, float width, float length, Color color, float scale = 1, float heigth = 0.1f)
    {
        // X,Y,Z gemeten in linker bovenhoek
        // startX and startZ => top left corner of rectangle around circle (200x200)
        // functie zo opgesteld dat je de waardes gemeten in GIMP gewoon kan overpakken
        // conversie van assenstelsel gebeurd hier

        X = X + width / 2;
        Z = Z + length / 2;
        Y = heigth / 2;
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(startX - (X * scale), startY + Y * scale, startZ + Z * scale);
        cube.transform.localScale = new Vector3(width * scale, heigth * scale, length * scale);
        cube.GetComponent<Renderer>().material.color = color;
        cubes.Add(cube);// add to list
        return cube;
    }
    void InitializeCubes(float scale = 1, float startX = 2000, float startY = 0, float startZ = 0) // scale = width of plane
    {
        startX *= scale;

        //starX/startZ -> linksebovenhoek
        // CreateRectanlge(startX, startY, startZ, x, y, z, width, legnth, color,scale);
        CreateRectanlge(startX, startY, startZ, 763, 1, 73, 85, 130, myRed, scale); //1
        CreateRectanlge(startX, startY, startZ, 853, 1, 73, 245, 95, myBlue, scale); //2
        CreateRectanlge(startX, startY, startZ, 357, 1, 302, 64, 57, myYellow, scale); //3
        CreateRectanlge(startX, startY, startZ, 426, 1, 301, 221, 58, myBlue, scale); //4
        CreateRectanlge(startX, startY, startZ, 853, 1, 301, 245, 121, myRed, scale); //5
        CreateRectanlge(startX, startY, startZ, 1216, 1, 173, 148, 204, myYellow, scale); //6
        CreateRectanlge(startX, startY, startZ, 651, 1, 427, 85, 112, myYellow, scale); //7
        CreateRectanlge(startX, startY, startZ, 1369, 1, 382, 56, 136, myRed, scale); //8
        CreateRectanlge(startX, startY, startZ, 357, 1, 543, 64, 210, myYellow, scale); //9
        CreateRectanlge(startX, startY, startZ, 562, 1, 543, 174, 150, myBlue, scale);
        CreateRectanlge(startX, startY, startZ, 853, 1, 523, 108, 16, myYellow, scale);
        CreateRectanlge(startX, startY, startZ, 1216, 1, 523, 148, 118, myBlue, scale);
        CreateRectanlge(startX, startY, startZ, 1500, 1, 460, 208, 181, myBlue, scale);
        CreateRectanlge(startX, startY, startZ, 426, 1, 758, 131, 58, myRed, scale);
        CreateRectanlge(startX, startY, startZ, 741, 1, 821, 107, 80, myRed, scale);
        CreateRectanlge(startX, startY, startZ, 853, 1, 646, 108, 170, myYellow, scale);
        CreateRectanlge(startX, startY, startZ, 1104, 1, 646, 107, 255, myRed, scale);
        CreateRectanlge(startX, startY, startZ, 1216, 1, 646, 148, 75, myYellow, scale);
        CreateRectanlge(startX, startY, startZ, 1500, 1, 683, 54, 103, myYellow, scale);
        CreateRectanlge(startX, startY, startZ, 1713, 1, 791, 89, 160, myYellow, scale);
        CreateRectanlge(startX, startY, startZ, 853, 1, 906, 108, 55, myYellow, scale);
        CreateRectanlge(startX, startY, startZ, 209, 1, 966, 174, 153, myBlue, scale);
        CreateRectanlge(startX, startY, startZ, 741, 1, 966, 107, 153, myBlue, scale);
        CreateRectanlge(startX, startY, startZ, 966, 1, 966, 69, 69, myRed, scale, 1);
        CreateRectanlge(startX, startY, startZ, 1141, 1, 966, 70, 70, myBlue, scale);
        CreateRectanlge(startX, startY, startZ, 1369, 1, 1039, 185, 80, myRed, scale);
        CreateRectanlge(startX, startY, startZ, 1559, 1, 956, 198, 163, myBlue, scale);
        CreateRectanlge(startX, startY, startZ, 1559, 1, 1124, 72, 137, myYellow, scale);
        CreateRectanlge(startX, startY, startZ, 1216, 1, 1209, 148, 109, myBlue, scale);
        CreateRectanlge(startX, startY, startZ, 966, 1, 1124, 170, 81, myYellow, scale);
        //CreateRectanlge(startX, startY, startZ,562,1,1123,286,151,myRed, scale); //  smaller
        CreateRectanlge(startX, startY, startZ, 624, 1, 1123, 222, 151, myRed, scale); //  smaller

        CreateRectanlge(startX, startY, startZ, 334, 1, 1201, 223, 162, myYellow, scale);
        CreateRectanlge(startX, startY, startZ, 334, 1, 1368, 107, 174, myRed, scale);
        CreateRectanlge(startX, startY, startZ, 666, 1, 1368, 67, 174, myBlue, scale);
        CreateRectanlge(startX, startY, startZ, 853, 1, 1279, 108, 84, myBlue, scale);
        CreateRectanlge(startX, startY, startZ, 853, 1, 1368, 108, 60, myYellow, scale);
        CreateRectanlge(startX, startY, startZ, 1141, 1, 1368, 70, 119, myRed, scale);
        CreateRectanlge(startX, startY, startZ, 1216, 1, 1368, 148, 174, myRed, scale);
        CreateRectanlge(startX, startY, startZ, 1534, 1, 1427, 97, 207, myRed, scale);
        CreateRectanlge(startX, startY, startZ, 1141, 1, 1639, 223, 87, myYellow, scale);
        CreateRectanlge(startX, startY, startZ, 891, 1, 1731, 70, 44, myYellow, scale);
        CreateRectanlge(startX, startY, startZ, 738, 1, 1547, 148, 179, myRed, scale);
        CreateRectanlge(startX, startY, startZ, 619, 1, 1547, 114, 63, myYellow, scale);
        CreateRectanlge(startX, startY, startZ, 200, 1, 1547, 129, 125, myBlue, scale);

    }
    GameObject InitializePlane(float scale = 1, float posX = 1000, float posY = 0, float posZ = 1000, float height = 200)
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
        plane.transform.position = new Vector3(posX, posY, posZ); // position
        plane.transform.localScale = new Vector3(width * scale, height, length * scale); // resize
        return plane;
    }
  
}



