# Using Meshroom

Meshroom is a free, open-source 3D Reconstruction Software based on the AliceVision Photogrammetric Computer Vision framework. We can use it as a photogrammetry program for scanning objects in real life and digitise them. We can then use these digital scans of real life models in Unity for our scripts. We do this by taking pictures at different angles of our object, then putting it in Meshroom and let it process.

## Installing Meshroom

- Go over to their site and download the latest binary (Linux/Windows only):
https://alicevision.github.io/#meshroom  
- Unzip to preferred location
- Run Meshroom.exe!
  
## Meshroom UI

When you open Meshroom it will open a console and a UI component, the console is handy for tracking progress but we're mainly interested in the UI. 

The layout is split up in 5 components, I'll explain them briefly here:
- Images: This is where you can drag & drop your pictures.  
- Image Viewer: If you click on a picture from the images list it previews it here. You'll use this to remove blurry pictures.  
- 3D  Viewer: You'll see a 3D object being made here, it's realtime so you can see your progress in real-time.
- Graph editor: Here you can tweak the settings if you desire, the default one is good for 90% of projects.  
- Progress tracker: Like the console for tracking progress but in the UI.  

![Meshroom On Startup](https://github.com/RobbeVermeire/BachelorClass2018/blob/master/Images/MeshroomOnStartUp.png)


## Using Meshroom 

Meshroom is not difficult to use, I'll quickly explain the steps you go through when making a 3D Model. I'm assuming that you already have the pictures of your model. If you need guidelines taking pictures you can download a pdf that gives guidelines [here](3dflow.net/zephyr-doc/3DF%20Zephyr%20Manual%202600%20English.pdf)
(3dflow.net/zephyr-doc/3DF%20Zephyr%20Manual%202600%20English.pdf)(Scroll down to Photography Guide).   
The guide is for a different photogrammetry program but the tips about taking pictures you can apply to Meshroom. 
A good amount of photos is 30 to 40 for a small object.

1) After you've taken your pictures you can simply drop & drag them in the Images component in Meshroom.
2) Remove any blurry photos, that way the computer has only clear photos for photogrammetry.
3) Save the project, that way you don't lose all your progress when something goes wrong.
4) Click on start, you'll see a green/yellow/blue bar appear at the top for tracking the progress.
5) When an error occurs you'll see a the bar become partly red. Look at the logs and try to fix it, mostly errors are related to bad pictures.

The 3D reconstruction of our object takes a long time and depends on how many images you have, the resolution of the images, your computer hardware and many more factors I won't discuss here.



