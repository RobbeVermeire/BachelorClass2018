# Importing a Tilt Brush sketch into Unity


## Set up your development environment
* Install Unity 3D - https://store.unity.com/
* Download the latest Poly Toolkit .unitypackage - [Releases page](https://github.com/googlevr/poly-toolkit-unity/releases)


## Create a project
1. In Unity, select **File > New Project**.

2. Name your project how you want, leave **3D** mode selected, and click **Create Project**.

If you are using Unity 2018.1 or above, you must enable unsafe code (Poly Toolkit uses _unsafe { ... }_ code blocks in C# for performance reasons). To do this:

3. Click **File > Build Settings**

4. Click **Player Settings** to bring up the Player Settings tab.

5. Find the **Allow 'unsafe' code** setting (under the **Other Settings** category) and enable it.

6. Click the menu **Assets > Import package > Custom package**, then select the _poly-toolkit-v*.unitypackage_ file you downloaded and import everything in the package.

7. The **Poly Asset Browser** window opens automatically after installation. You can also open this window by selecting **Poly > Browse assets** from the menu.
