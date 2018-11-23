# Setting up a new Unity VR project
When the project is already created on another device, we will only have access to the development files. This means this is not a full Unity project.

To be able to work on the project in Unity, to the following steps:

1. Go to the folder in the upper map which is called "Unity_Template_Project" and enter it.� (F:\EPS_Story\UnityProjects\Github_Repo\Projects )

2. Copy all files in this folder (CTRL + A, then CTRL + V =&gt; command for Apple)

3. Go to the project on which to work and open it

4. Paste all the files you copied (CTRL + V)

5. !!! The computer will prompt to ask to overwrite or skip already existing files. Make sure that you SKIP THE ALREADY EXISTING FILES. Do not overwrite them.

6. Delete file: Unity_Template_Project.sln

7. Add two next folders in de Asset folder if not there already (store these two folders locally out of github repo so you don't have to download it everytime):

- SteamVR: https://github.com/ValveSoftware/steamvr_unity_plugin =&gt; enter "Assets" and the folder SteamVR is the one you need to copy to your own "Assets" folder

- VRTK: https://github.com/thestonefox/VRTK.git� =&gt; same as above, but with VRTK folder

8. Open the project in Unity and the rest will be automatically generated.

9. Click the MainScene object in the Asset folder in Unity to open the working space, unless creating new scene.

## To start the simulator:

1. Disable the [CameraRig] by clicking on the item, then clicking the checkbox next to the name in the Inspector Box.

2. Enable both VRTK_SDK Manager and VRTK_SDK Setup

3. In the VRTK_SDK Setup object set SDK Selection to "Simulator". (Auto Populate should be enabled)

4. In the VRTK_SDK Manager object click on the button "Auto Populate" (all Setup objects will be detected for the Manager to manage)

5. Open the VRTK_SDK Setup object, which contains next object "VRSimulatorCameraRig", click on this. At the bottom in the Inspector box is a script attached: "VideoScript" with a public variable "Video Player". Drag the Video Player object from the Hierarchy tab into the field of the public variable.

When making a new project, we only push necessary files to Github and not those that do not have an effect on the development of the project. This means we'll have to create those files before we start working remotely on a project.

We have a template from which we will ALWAYS create a new project. This template will be the source of new updates and important changes.

Here is how to do it:

1. In the repo, there is a folder named "Unity_Template_Project". Copy this folder.

2. Go in the folder "Projects"

3. Paste the copied folder (keep a clean structure)

4. Change name of the folder to the desired name

5. Add two next folders in de Asset folder* (store these two folders locally so you don't have to download it everytime):

- SteamVR: https://github.com/ValveSoftware/steamvr_unity_plugin =&gt; enter "Assets" and the folder SteamVR is the one you need to copy to your own "Assets" folder

- VRTK: https://github.com/thestonefox/VRTK.git� =&gt; same as above, but with VRTK folder

6. Open the project in Unity (other needed files will be automatically generated)

In case of pushing something unwanted to github, do next steps:

1. Delete the file/folder from you device

2. "git add ."

3. "git commit -a -m "delete X"

4. push to github

We use SteamVR for developing in Unity with the VR headset. VRTK is used for developing without a headset, which uses a VR simulator. If working with headseat (default), disable (checkbox left of name in Inspector box): VRTK_SDK Manager and VRTK_SDK Setup objects in the scene. If working without headset, enable VRTK objects and disable [CameraRig] object.