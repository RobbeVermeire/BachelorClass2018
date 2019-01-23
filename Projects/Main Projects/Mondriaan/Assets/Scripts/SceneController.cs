using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Video;


/* Created by Joris Van Looy, student 3EA1 2018-2019 AP hogeschool Antwerpen
 * 
 * The story :
 * Viewer starts at the center of a Mondriaan painting, surrounded by an endless white void.
 * Slowly the cubes of the painting start rising, the further away from the viewer, the higher they rise.
 * When they are all at max height, the viewer will see colored persons appear from behind the cubes.
 * The viewer can at all times only see one person at a time.
 * There are 3 diffrent persons, blue, yellow and red. They start to touch the cubes, changing them to their own color.
 * The red person, wins in the end, and all cubes end up red.
 * 
 */

public class SceneController : MonoBehaviour {

    public GameObject CameraRig;

    public RisingCubes RisingCubes;
    public Shader Scene_Shader;

    public Material Scene_Red_Material;   
    public RenderTexture Scene_Red_RenderTexture;
    public VideoClip Scene_Red_VideoClip;

    public Material Scene_Blue_Material;
    public RenderTexture Scene_Blue_RenderTexture;
    public VideoClip Scene_Blue_VideoClip;

    public Material Scene_Yellow_Material;
    public RenderTexture Scene_Yellow_RenderTexture;
    public VideoClip Scene_Yellow_VideoClip;

    private VideoScene Scene1;
    private EmptyScene Scene2;
    private VideoScene Scene3;
    private EmptyScene Scene4;
    private VideoScene Scene5;
    private EmptyScene Scene6;
    private VideoScene Scene7;
    private EmptyScene Scene8;
    private VideoScene Scene9;
    private EmptyScene Scene10;
    private EmptyScene Scene11;
    private EmptyScene Scene12;
    private EmptyScene Scene13;
    private EmptyScene Scene14;
    private EmptyScene Scene15;
    private EmptyScene Scene16;
    private VideoScene Scene17;

    private Vector3 cameraRot;
    private Vector3 cameraPos;
    private float TimeSinceStartup;

    private Controller controller;

    // Use this for initialization
    void Start () {
        
        Scene1 = new VideoScene(Scene_Red_Material, Scene_Shader, Scene_Red_RenderTexture, Scene_Red_VideoClip, 0f, 21.4f, new Vector3(0,-13f,0), new Vector3(1000, 118, 1000), new Vector3(974.6f, 974.6f, 974.6f));
        var event1_1 = new ChangeScaleEvent(Scene1.sphere,Scene1.videoPlayer, 16, 29.4f, 20);
        var event1_2 = new ChangeCubeColorTimerEvent(Scene1.videoPlayer, 13.3f, RisingCubes.cubes.ToArray(), new int[] { 31 }, new int[] { }, new int[] { });
        Scene1.AddEvent(event1_1);
        Scene1.AddEvent(event1_2);

        Scene2 = new EmptyScene(); // waits for all events to be over
        var event2_1 = new LookAtEvent(CameraRig, 0, 35); // look between 325° and 35°
        Scene2.AddEvent(event2_1);

        Scene3 = new VideoScene(Scene_Blue_Material, Scene_Shader, Scene_Blue_RenderTexture, Scene_Blue_VideoClip, 53.2f, 77, new Vector3(0, 220.7f, 0), new Vector3(1000, 145, 1000), new Vector3(1050, 1050, 1050));
        var event3_1 = new MakeInvisibleWhenLookingAt(Scene3.sphere, CameraRig, 260, 30);
        var event3_2 = new ChangePositionEvent(Scene3.sphere, Scene3.videoPlayer, 62, 72, -9);
        var event3_3 = new ChangeCubeColorTimerEvent(Scene3.videoPlayer, 73.35f, RisingCubes.cubes.ToArray(), new int[] {  }, new int[] { }, new int[] {36 });
        var event3_4 = new ChangeCubesColorEvent(RisingCubes.cubes.ToArray(), new int[] { 6, 20, 2, 0, 18 }, new int[] { }, new int[] { });
        Scene3.AddEvent(event3_1);
        Scene3.AddEvent(event3_2);
        Scene3.AddEvent(event3_3);
        Scene3.AddEvent(event3_4);

        Scene4 = new EmptyScene();
        var event4_1 = new LookAtEvent(CameraRig, 0, 35);
        Scene4.AddEvent(event4_1);

        Scene5 = new VideoScene(Scene_Red_Material, Scene_Shader, Scene_Red_RenderTexture, Scene_Red_VideoClip, 46.5f, 59.7f, new Vector3(0, 285, 0), new Vector3(1000, 118, 1000), new Vector3(1020, 1020, 1020));
        var event5_1 = new ChangeCubesColorEvent(RisingCubes.cubes.ToArray(), new int[] { 13,5,21 }, new int[] { }, new int[] { });
        var event5_2 = new ChangeCubeColorTimerEvent(Scene5.videoPlayer, 51.3f, RisingCubes.cubes.ToArray(), new int[] { 39 }, new int[] { }, new int[] {});
        Scene5.AddEvent(event5_1);
        Scene5.AddEvent(event5_2);

        Scene6 = new EmptyScene(); // waits for all events to be over
        var event6_1 = new LookAtEvent(CameraRig, 115, 35); // look between 80° and 150°
        Scene6.AddEvent(event6_1);

        Scene7 = new VideoScene(Scene_Yellow_Material, Scene_Shader, Scene_Yellow_RenderTexture, Scene_Yellow_VideoClip, 24.7f, 51.3f, new Vector3(0, -11f, 0), new Vector3(1000, 110, 1000), new Vector3(954, 954, 954));
        var event7_1 = new ChangeScaleEvent(Scene7.sphere, Scene7.videoPlayer, 30, 37, 18);
        var event7_2 = new ChangeScaleEvent(Scene7.sphere, Scene7.videoPlayer, 37, 45, -12);
        var event7_3 = new ChangeCubesColorEvent(RisingCubes.cubes.ToArray(), new int[] { 40,41,18,19,27,24,35 }, new int[] { }, new int[] { });
        var event7_4 = new ChangeCubeColorTimerEvent(Scene7.videoPlayer, 36.3f, RisingCubes.cubes.ToArray(), new int[] {  }, new int[] {31 }, new int[] { });
        var event7_5 = new ChangeCubeColorTimerEvent(Scene7.videoPlayer, 47.9f, RisingCubes.cubes.ToArray(), new int[] { }, new int[] { 13 }, new int[] { });
        Scene7.AddEvent(event7_1);
        Scene7.AddEvent(event7_2);
        Scene7.AddEvent(event7_3);
        Scene7.AddEvent(event7_4);
        Scene7.AddEvent(event7_5);

        Scene8 = new EmptyScene();
        var event8_1 = new LookAtEvent(CameraRig, 200, 30);
        Scene8.AddEvent(event8_1);

        Scene9 = new VideoScene(Scene_Red_Material, Scene_Shader, Scene_Red_RenderTexture, Scene_Red_VideoClip, 67, 80.18f, new Vector3(0, 83, 0), new Vector3(1000, 105, 1000), new Vector3(1062, 1062, 1062));
        var event9_1 = new ChangeCubesColorEvent(RisingCubes.cubes.ToArray(), new int[] { 39,40,31,29,19 }, new int[] { }, new int[] { });
        var event9_2 = new ChangeCubeColorTimerEvent(Scene9.videoPlayer, 70.8f, RisingCubes.cubes.ToArray(), new int[] {10 }, new int[] { }, new int[] { });
        var event9_3 = new ChangeCubeColorTimerEvent(Scene9.videoPlayer, 76.46f, RisingCubes.cubes.ToArray(), new int[] { 11 }, new int[] { }, new int[] { });
        Scene9.AddEvent(event9_1);
        Scene9.AddEvent(event9_2);
        Scene9.AddEvent(event9_3);

        Scene10 = new EmptyScene();
        var event10_1 = new LookAtEvent(CameraRig, 245, 35);
        Scene10.AddEvent(event10_1);

        Scene11 = new EmptyScene();
        var event11_1 = new ChangeCubesColorEvent(RisingCubes.cubes.ToArray(), new int[] { 33,34,42,43 }, new int[] { }, new int[] { });
        Scene11.AddEvent(event11_1);

        Scene12 = new EmptyScene();
        var event12_1 = new LookAtEvent(CameraRig, 90, 30);
        Scene12.AddEvent(event12_1);

        Scene13 = new EmptyScene();
        var event13_1 = new ChangeCubesColorEvent(RisingCubes.cubes.ToArray(), new int[] { 17,12,26,36,28 }, new int[] { }, new int[] { });
        Scene11.AddEvent(event13_1);

        Scene14 = new EmptyScene();
        var event14_1 = new LookAtEvent(CameraRig, 335,35);
        Scene14.AddEvent(event14_1);

        Scene15 = new EmptyScene();
        var event15_1 = new ChangeCubesColorEvent(RisingCubes.cubes.ToArray(), new int[] { 1,9,15,22,3,8}, new int[] { }, new int[] { });
        Scene15.AddEvent(event15_1);

        Scene16 = new EmptyScene();
        var event16_1 = new LookAtEvent(CameraRig, 0, 30);
        Scene16.AddEvent(event16_1);

        Scene17 = new VideoScene(Scene_Red_Material, Scene_Shader, Scene_Red_RenderTexture, Scene_Red_VideoClip, 57.2f, 64.3f, new Vector3(0, 303, 0), new Vector3(1000, 109, 1000), new Vector3(1076, 1076, 1076));

        //add scenes in correct order
        controller = new Controller();
        controller.AddScene(Scene1);
        controller.AddScene(Scene2);
        controller.AddScene(Scene3);
        controller.AddScene(Scene6);
        controller.AddScene(Scene7);
        controller.AddScene(Scene4);
        controller.AddScene(Scene5);
        controller.AddScene(Scene8);
        controller.AddScene(Scene9);
        controller.AddScene(Scene10);
        controller.AddScene(Scene11);
        controller.AddScene(Scene12);
        controller.AddScene(Scene13);
        controller.AddScene(Scene14);
        controller.AddScene(Scene15);
        controller.AddScene(Scene16);
        controller.AddScene(Scene17);

    }

    // Update is called once per frame
    void Update () {

        UpdateTimers();
        UpdateCamera();
        if (TimeSinceStartup >= 70f && !Scene1.IsStopped && !Scene1.IsPlaying)// start first scene from outside of the controller
        {
            Scene1.Start = true;
        }
        controller.Update();
    }
    public void UpdateCamera()
    {
        cameraRot = CameraRig.transform.rotation.eulerAngles;
        cameraPos = CameraRig.transform.position;
    }

    public void UpdateTimers()
    {
        //Debug.Log(TimeSinceStartup);
        TimeSinceStartup += Time.deltaTime;
    }



    //----  USED CLASSES ----//


    // A scene is used for everything, playing video, changing colors of objects, triggering events,..
    public class Scene
    {
        public bool IsPlaying { get; set; }
        public bool IsStopped { get; set; } 
        public bool IsPrepared { get; set; }
        public bool IsPaused { get; set; }
        public bool Start { get; set; }

        public List<Event> Events;
        public Scene() { Events = new List<Event>(); Start = false;}
        public virtual void Update() { }
        public void AddEvent(Event _event) { Events.Add(_event); }
        public void UpdateEvents() { foreach(Event e in Events) { e.Update(); } }
    }

    //An EmtpyScene is a scene without video, this scene will end when all the events or done.
    public class EmptyScene : Scene // used for events between videos
    {        
        public bool EventsEnded;
        public EmptyScene():base()
        {

        }
        public override void Update()
        {
            if (Start)
            {
                if (!IsPlaying)
                {
                    IsPlaying = true;
                }
                
                base.UpdateEvents();

                if(Events.All(x => x.IsDone == true))
                {
                    IsPlaying = false;
                    IsStopped = true;
                }

            }

        }
    }

    // VideoScene is used for videos, it will stop when the video ends (specifc time)
    // can have multiple evenets
    public class VideoScene : Scene
    {
        public VideoClip VideoClip;
        public VideoPlayer videoPlayer;
        public GameObject sphere;        

        public float startTime;
        public float stopTime;
        public Vector3 rotation;
        public Vector3 startScale;
        public Vector3 startPosion;

        public float timeSinceStart;
        private bool firstUpdateFrame = false;

        //private List<SceneEvent> Events;

        public VideoScene(Material _renderMaterial,Shader _renderShader,RenderTexture _renderTexture, VideoClip _clip, float _startTime, float _stopTime, Vector3 _rotation, Vector3 _startPos, Vector3 _starScale):base()
        {
            startTime = _startTime;
            stopTime = _stopTime;
            rotation = _rotation;
            startScale = _starScale;
            startPosion = _startPos;
            VideoClip = _clip;
            
            sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            _renderMaterial.shader = _renderShader;
            _renderMaterial.SetTexture("_renderTexture",_renderTexture);
            sphere.GetComponent<Renderer>().material = _renderMaterial;
            sphere.GetComponent<Renderer>().enabled = false;

            videoPlayer = sphere.AddComponent<VideoPlayer>();
            videoPlayer.renderMode = VideoRenderMode.RenderTexture;
            videoPlayer.targetTexture = _renderTexture;
            videoPlayer.SetDirectAudioMute(0, true);
            //videoPlayer.url = "Assets/Footage/" + _videoName; => causes lag???
            videoPlayer.clip = VideoClip;
            videoPlayer.aspectRatio = VideoAspectRatio.NoScaling;
            videoPlayer.playOnAwake = false;
            Prepare();           
        }
        public override void Update()
        {
            if(videoPlayer.isPrepared && videoPlayer.canSetTime && !IsPlaying)
            {
                videoPlayer.time = startTime;
                videoPlayer.Pause();
            }
            if (!firstUpdateFrame) // only print first updating frame
            {
                firstUpdateFrame = true;
            }
            if (!IsPaused)
            {
                timeSinceStart += Time.deltaTime;
            }
            if (videoPlayer.isPrepared && !IsPrepared)
            {
                IsPrepared = true;          
                sphere.GetComponent<Renderer>().enabled = false;
            }
            if (Start && !IsPlaying && IsPrepared && !IsStopped)
            {
                Play();            
            }
            if (videoPlayer.time >= stopTime && !IsStopped && IsPlaying)
            {
                Stop();
            }

            if (IsPlaying)
            {
                base.UpdateEvents();
            }
                       
        }
        public void Prepare()
        {        
            sphere.transform.Rotate(rotation, Space.World);
            sphere.transform.position = startPosion;
            sphere.transform.localScale = startScale;           
            videoPlayer.Prepare();
        }
        public void Play()
        {           
            sphere.GetComponent<Renderer>().enabled = true;
            videoPlayer.Play();
            IsPlaying = true;
            IsPaused = false;
            IsStopped = false;
            firstUpdateFrame = false;
        }
        public void Pause()
        {
            videoPlayer.Pause();
            IsPlaying = false;
            IsPaused = true;
            IsStopped = false;
            firstUpdateFrame = false;
        }
        public void Stop()
        {
            videoPlayer.Stop();
            IsPlaying = false;
            IsPaused = false;
            IsStopped = true;
            sphere.transform.localScale = new Vector3(0, 0, 0);
            sphere.GetComponent<Renderer>().enabled = false;
            sphere.transform.rotation = Quaternion.identity;
        }
        
    }

    public class Event
    {
        public bool IsDone;
        public Event()
        {
            IsDone = false;
        }
        public virtual void Update(){ }
    }

    // Changes color of multiple cubes at startup of parent scene
    public class ChangeCubesColorEvent : Event
    {
        public GameObject[] cubes;
        public int[] cubes_to_red;
        public int[] cubes_to_yellow;
        public int[] cubes_to_blue;

        private string hex_blue = "#26348b";
        private Color myBlue;

        private string hex_yellow = "#ffdd0e";
        private Color myYellow;

        private string hex_red = "#e30613";
        private Color myRed;
        public ChangeCubesColorEvent(GameObject[] _cubes,int[] _cubes_to_red,int[] _cubes_to_yellow, int[] _cubes_to_blue)
        {
            cubes_to_red = _cubes_to_red;
            cubes_to_yellow = _cubes_to_yellow;
            cubes_to_blue = _cubes_to_blue;

            cubes = _cubes;

            myBlue = new Color();
            ColorUtility.TryParseHtmlString(hex_blue, out myBlue);
            myYellow = new Color();
            ColorUtility.TryParseHtmlString(hex_yellow, out myYellow);
            myRed = new Color();
            ColorUtility.TryParseHtmlString(hex_red, out myRed);
        }

        public override void Update()
        {
            if (!IsDone)
            {
                for(int i = 0; i < cubes_to_blue.Length; i++)
                {
                    cubes[cubes_to_blue[i]].GetComponent<Renderer>().material.color = myBlue;
                }
                for (int i = 0; i < cubes_to_red.Length; i++)
                {
                    cubes[cubes_to_red[i]].GetComponent<Renderer>().material.color = myRed;
                }
                for (int i = 0; i < cubes_to_yellow.Length; i++)
                {
                    cubes[cubes_to_yellow[i]].GetComponent<Renderer>().material.color = myYellow;
                }
                IsDone = true;
            }
        }
    }


    //Change color of multiple cubes at specifc video time of parent scene
    public class ChangeCubeColorTimerEvent : ChangeCubesColorEvent
    {
        public VideoPlayer videoPlayer;
        public float time;
        public ChangeCubeColorTimerEvent(VideoPlayer _videoPlayer,float _time,GameObject[] _cubes, int[] _cubes_to_red, int[] _cubes_to_yellow, int[] _cubes_to_blue ) : base(_cubes, _cubes_to_red, _cubes_to_yellow, _cubes_to_blue)
        {
            videoPlayer = _videoPlayer;
            time = _time;
        }

        public override void Update()
        {
            if(videoPlayer.time>= time)
            {
                base.Update();
            }           
        }
    }

    // An event that has a specific start/stop time (time of parent scene videoplayer)
    public class TimeEvent : Event
    {
        public double startTime;
        public double endTime;
        public float eventLegnth;
        public VideoPlayer videoPlayer;
        public TimeEvent(float _startTime ,float _endTime,VideoPlayer _videoPlayer ): base()
        {
            startTime = _startTime;
            endTime = _endTime;
            eventLegnth = (float)endTime - (float)startTime;
            videoPlayer = _videoPlayer;
        }
        public override void Update()
        {           
            if(videoPlayer.time >= startTime && videoPlayer.time <= endTime)
            {
                Event();
            }else if(videoPlayer.time > endTime)
            {
                IsDone = true;
            }          
        }
        public virtual void Event(){ }
    }

    //Changes scale of render texture (cube), sometimes needed to have good reality/VR mapping
    //using time event to smooth the change out
    public class ChangeScaleEvent : TimeEvent
    {
        public GameObject sphere;
        private float changeInScale;
        private float changeInScaleInteravl;
        private float startScale;
        
        public ChangeScaleEvent(GameObject _sphere,VideoPlayer _videoPlayer,float _startTime, float _endTime, float _changeInScale) : base(_startTime,_endTime, _videoPlayer)
        {
            sphere = _sphere;
            startScale = sphere.transform.localScale.y;
            changeInScale = _changeInScale;
            changeInScaleInteravl = changeInScale / eventLegnth;
        }

        public override void Event()
        {
           
            var change = Mathf.Abs(changeInScaleInteravl)* Time.deltaTime;
            if(changeInScale > 0)
            {
                if(sphere.transform.localScale.y <= startScale + Mathf.Abs(changeInScale))
                {
                    sphere.transform.localScale += new Vector3(change, change, change);
                }
            }
            else
            {
                if (sphere.transform.localScale.y >= startScale - Mathf.Abs(changeInScale))
                {
                    sphere.transform.localScale -= new Vector3(change, change, change);
                    
                }
            }
        }
    }

    //Changes position(height) of render texture (cube), sometimes needed to have good reality/VR mapping
    //using time event to smooth the change out
    public class ChangePositionEvent : TimeEvent
    {
        public GameObject sphere;
        private float changeInPosition;
        private float changeInPositionInterval;
        private float startPosition;

        public ChangePositionEvent(GameObject _sphere, VideoPlayer _videoPlayer, float _startTime, float _endTime, float _changeInPosition) : base(_startTime, _endTime, _videoPlayer)
        {
            sphere = _sphere;
            startPosition = sphere.transform.position.y;
            changeInPosition = _changeInPosition;
            changeInPositionInterval = Mathf.Abs(changeInPosition) / eventLegnth;
        }

        public override void Event()
        {

            var change = changeInPositionInterval * Time.deltaTime;
            if (changeInPosition > 0)
            {
                if (sphere.transform.position.y <= startPosition + Mathf.Abs(changeInPosition))
                {
                    sphere.transform.position += new Vector3(0, change, 0);
                }
            }
            else
            {
                if (sphere.transform.position.y >= startPosition - Mathf.Abs(changeInPosition))
                {
                    sphere.transform.position -= new Vector3(0, change, 0);

                }
            }
        }
    }

    // Simple event that ends when cameraRig is looking at specific angle
    public class LookAtEvent : Event
    {
        public GameObject cameraRig;
        public Vector3 cameraRot;
        public float degree;
        public float marge;
        public LookAtEvent(GameObject _cameraRig,float _degree,float _marge):base()
        {
            cameraRig = _cameraRig;
            degree = _degree;
            marge = _marge;
        }
        public override void Update()
        {
            if (!IsDone)
            {
                cameraRot = cameraRig.transform.rotation.eulerAngles;
                IsDone = LookAt(degree, marge);
            }
        }
        public bool LookAt(float _degree, float _marge) 
        {
            if (_degree + _marge < 360 && _degree - _marge > 0)
            {
                if (cameraRot.y > _degree - _marge && cameraRot.y < _degree + _marge)
                {
                    return true;
                }
            }
            else
            {
                var x = _degree - _marge;
                if(x < 0)
                {
                    x = 360 + x; 
                }
                if ((cameraRot.y > x && cameraRot.y <= 360) || (cameraRot.y > 0 && cameraRot.y < _degree + _marge - 360) || cameraRot.y == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }

    // event that makes video invinsible when looking at specifc angle
    // sometimes needed mapping reality with VR
    public class MakeInvisibleWhenLookingAt : LookAtEvent
    {
        public GameObject sphere;
        public MakeInvisibleWhenLookingAt(GameObject _sphere,GameObject _cameraRig, float _degree, float _marge): base(_cameraRig,_degree,_marge)
        {
            IsDone = true; // don't let scene wait for this event to end, events runs as long the scene runs
            sphere = _sphere;
        }
        public override void Update()
        {
            cameraRot = cameraRig.transform.rotation.eulerAngles;
            if (LookAt(degree, marge))
            {
                 sphere.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                sphere.GetComponent<Renderer>().enabled = true;
            }
        }

    }

    // controller will check if current scene is ended, and start next scene
    public class Controller 
    {
        public List<Scene> Scenes { get; set; }
        private int currentScene;
        public Controller( )
        {
            Scenes = new List<Scene>();
            currentScene = 0;
        }

        public void Update()
        {
            if(currentScene < Scenes.Count)
            {
                if(currentScene != 0 && !Scenes[currentScene].Start) //start first scene from outside
                {
                    Scenes[currentScene].Start = true;
                }
                if (Scenes[currentScene].IsStopped)
                {
                    currentScene++;
                    var sceneNumber = currentScene + 1;
                    Debug.Log("SCENE " + sceneNumber + " STARTED.");
                }               
            }
            foreach (Scene s in Scenes)
            {
                s.Update();
            }
        }
        public void AddScene(Scene _scene)
        {
            Scenes.Add(_scene);
        }
    }

}
