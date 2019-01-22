## Render a 360° video on inside of a sphere with alpha channel.

### Introduction
We will create a 360° video with an alpha channel. This video will be rendered on the inside of a sphere, and the alpha channel will be made transparent. So the viewer, located on the vertical diagonal trough the center of the circle, will only be able to see the non-alpha channel part of the video. The rest of the video is transparent, so VR objects or other spheres with 360° videos outside the original sphere are visible.

After, we will learn how to map the 360° video on a VR generated world. This is necessary to obtain the most realistic result, so the 360° video and VR world/objects merge into one being.

### Why is this useful?
This allows you to combine filmed footage with virtually generated objects in unity without limitations.

We can film a view outdoors, view indoors, view inside an object,.. everything you want really, all in 360° of course, and place virtual objects in it, without the objects blocking the view. As we know, virtual objects are very easy to manipulate, so the possibilities are endless.

Or we can switch the filmed footage with the virtual objects and create a virtual landscape, and add a filmed human, animal, real object, animation,.. . 

We only used this type of VR-reality combination in our Mondriaan project and in the examples below.


#### 1. Create a 360 video
You will need a 360° video with an alpha channel. We started with a .mov file. You  have to think about distances in unity before you start filming.(We can do some editing and video depth manipulation afterwards, so we can fix film mistakes in Unity if needed). 
Because the camera has to be in the center of the sphere, it’s not so easy to enlarge/reduce the size of the non-alpha object(s) in the 360° video. This also can be manipulated a little in Unity go to '5. Map the 360° video in Unity' for further info.

So, decide on how far the object has to be from the viewer in unity, and how big it has to be. 

Think about how the video has to start/end, example:

In our project, a person (filmed in 360°), appears suddenly and then disappears again. You can't just make then appear/disappear in a blank area, this won't give a 'reality' feeling. So what we did, is, make the person appear from behind a Unity object, and disappear again behind one. When the person is behind an object, we can start/stop the video without the viewer knowing it.

There are many options for doing this, we only used the example above in our project.

Also think about stitching, more specific, about the position of the 360° video stitching. Try to avoid the stitching at an important part of the video.

The keying of the 360° video is also very important, this will make or break your 'reality' effect in Unity, spend enough time on keying to obtain the best result in Unity when making the alpha channel transparent.

#### 2. Convert video and import into unity
.webm is a video format that can be imported into unity and keeps his alpha channel.

[YouTube: How to import Transparent Video in Unity](https://www.youtube.com/watch?v=rlC95aTKzm0)

Don’t forget to check the "Keep Alpha" option after importing the video!

When developing, it can help/save time to reduce the import quality of the 360° video in Unity (bitrate mode and spatial quality). So lower end PC's can play it smoothly when using the VRTK VR simulator.

![Alt Text](https://github.com/RobbeVermeire/BachelorClass2018/blob/master/Images/VideoImportSettings.png)

#### 3. Create render texture for 360° video

1. Add a sphere object in your unity project.
2. Create a new (video)material. Add the material to the sphere.
3. Add the custom "FlippedWithTransparency" shader to the material you just added to the sphere.
4. Create a new (video)texture. Change the size to the 360° video resolution.
5. Add the texture to the material of the sphere.
6. Create a Video Player object.
7. Add your imported .webm video to the videoplayer.
8. Set render mode to "Render Texture".
9. Set the video texture as "Target Texture".
10. Change the position of the sphere to the camera objects position (only y value may differ, but the camera always has to be inside of the sphere!).
11. Don’t forget to make your sphere big enough!(x, y and z scale should always be the same).

The custom shader will flip your video, render it on the inside of the sphere and make the alpha channel transparent.

You can change the video player settings as you want, the only important setting is "Target Texture". 

It maybe helps to change the skybox to a single color, so you can see the result of your transparent video better.

### 4. Using the Videoplayer in Unity

Importing the video in script:
We noticed that when importing multiple 360 videos, setting the VideoPlayer.url property causes video lag when playing them. Instead we imported the videos using public VideoClip objects. Then setting the VideoPlayer.clip property.

Preparing the video:
In Unity, when using the Videoplayer, a video has to be prepared before you can play/customize it. So at startup, prepare all your videos using Videoplayer.Prepare().

Customizing the video:
We can set the Videoplayer.Time property to fast-forward to a specific part of the video.
To set the video invisible, use Sphere.GetComponent<Renderer>().enabled = false (where Sphere is the object with the target texture). Or set the scale of the Sphere to (0,0,0).

#### 5. Map the 360° video in Unity

Some techniques we using in our project:

Enlarging the target texture resolution (When doing this, set VideoPlayer.aspectRatio = VideoAspectRatio.NoScaling). Now the video will be played on only a portion of the sphere, all the rest will be transparent. This results in reducing the size of your 360 video (so your filmed objects/persons look smaller). Watch out tho, now your 360 video will not be fully 360 anymore, so there is an empty space between the 2 parts where the 360 video normally stitches together. It is important to keep the same scaling for the width/height of your target texture when changing size, so your video won't stretch.

Changing the Sphere scale (all three axis). This will change the depth of the 360 video compared to your Unity world, without changing its size. We can change this incremental during the video if needed.

![Alt Text](https://github.com/RobbeVermeire/BachelorClass2018/blob/master/Images/ChangeScale1.png)
![Alt Text](https://github.com/RobbeVermeire/BachelorClass2018/blob/master/Images/ChangeScale2.png)

Change the y position of the sphere/cameraRig. You can change this parameter if your 360° video object/person is not perfectly mapped on your Unity floor. We can also change this incremental during the video if needed.

![Alt Text](https://github.com/RobbeVermeire/BachelorClass2018/blob/master/Images/ChangePosition1.png)
![Alt Text](https://github.com/RobbeVermeire/BachelorClass2018/blob/master/Images/ChangePosition2.png)
![Alt Text](https://github.com/RobbeVermeire/BachelorClass2018/blob/master/Images/ChangePosition3.png)


