## Render a 360° video on inside of a sphere with alpha channel.

### Introduction
We will create a 360° video with an alpha channel. This video will be rendered on the inside of a sphere, and the alpha channel will be made transparent. So the viewer, located on the vertical diagonal trough the center of the circle, will only be able to see the non-alpha channel part of the video. The rest of the video is transparent, so VR objects or other spheres with 360° videos outside the original sphere are visible.

### Why is this useful?
This allows you to combine filmed footage with virtually generated objects in unity without real limitations.

We can film a view outdoors, view indoors, view inside an object,.. everything you want really, all in 360° of course, and place virtual objects in, without the objects blocking the view. As we know, virtual objects are very easy to manipulate, so the possibilities are endless.

Or we can switch the filmed footage with the virtual objects and create a virtual landscape, and add a filmed human, animal, real object, animation,.. . 


#### 1. Create a 360 video
You will need a 360° video with an alpha channel. We started with a .mov file. You  have to think about distances in unity before you start filming. 
Because the camera has to be in the center of the sphere, it’s not so easy to enlarge/reduce the size of the non-alpha object(s) in the 360° video. We can resize the sphere of course, but this means that objects will be further away of the viewer.

So, decide on how far the object has to be from the viewer in unity, and how big it has to be.

TODO possible to use aftereffects/fotoshop to scale video?

#### 2. Convert video and import into unity
.webm is a video format that can be imported into unity and keeps his alpha channel.

[YouTube: How to import Transparent Video in Unity](https://www.youtube.com/watch?v=rlC95aTKzm0)

Don’t forget to check the "Keep Alpha" option after importing the video!

IMPORTANT: Change codec to H264 in the importsettings of the video in unity. This prevents lag when the .webm video is played in unity.
![alt text](https://github.com/RobbeVermeire/BachelorClass2018/blob/master/Images/VideoImportSettings.png)

#### 3. Create render texture for 360° video

1. Add a sphere object in your unity project.
2. Create a new (video)material. Add the material to the sphere.
3. Add the custom "FlippedWithTransparency" shader to the material you just added to the sphere.
4. Create a new (video)texture. Change the size to the videos resolution.
5. Add the texture to the material of the sphere.
6. Create a Video Player object.
7. Add your imported .webm video to the videoplayer.
8. Set render mode to "Render Texture".
9. Set the video texture as "Target Texture".
10. Change the position of the sphere to the camera objects position (only y value may differ, but the camera always has to be inside of the sphere!).
11. Don’t forget to make your sphere big enough!(x, y and z scale should always be the same).

The custom shader will flip your video, render it on the inside of the sphere and make the alpha channel transparent.

You can change the video player settings as you want, the only import setting is "Target Texture". 

It maybe helps to change the skybox to a single color, so you can see the result of your transparent video better.

