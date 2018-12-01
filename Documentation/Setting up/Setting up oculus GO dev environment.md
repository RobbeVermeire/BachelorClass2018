# Setting up oculus GO development environment
Note that not all software referenced was good to use at the time of writing. But if some things do not work properly try using different versions or google for potential bugs.


## Downloading the right software
You will need to download 3 things:
* Unity 3D - https://store.unity.com/
* Android Studio - https://developer.android.com/studio/
* Oculus Core Utilities - https://developer.oculus.com/downloads/package/oculus-utilities-for-unity-5/

Next install these programs but make sure when installing Unity to add **Android Build support**.


## Android Development Software Setup
1. Open Android Studio.

2. On the welcome screen, click **Configure** on the bottom right, and then **SDK Manager**.

3. Under the SDK Platforms tab, make sure API Levels **21** through the **newest API level** are checked.

4. On the **SDK Tools** tab, check the box next to *Show Package Details* in the lower right corner of the window.

5. Under Android **SDK Build-Tools 28-rc2**, make sure the highest numbered item is check **that does not end with “-rc1” or “-rc2”**. As of this writing, that is **28.0.3**.

6. Also under **SDK Tools** make sure the follow are checked:
    > LLDB

    > Android SDK Platform-Tools

    > Android SDK Tools

    > NDK

7. Click **Apply**. This will install everything you selected above on the SDK tabs.

8. Back on the welcome screen, click **Configure** on the bottom right, and then **Project Defaults > Project Structure**.

9. Here you’ll see the file paths for the **SDK**, **JDK** and **NDK**. Copy these down in a text editor, we’ll need these shortly.

Now you will need to set your “environment variables”:

10. On your Windows machine, search for “Environment Variables”. This should take you to **Control Panel > System Properties**. Go to the **Advanced Tab**, then to the **Environment Variables** button in the lower right.

11. In the top section, add or modify the following variables as you wrote down in the text editor:
    > Add or modify the environment variable **JAVA_HOME** to the JDK location.

    > Add or modify the environment variable **ANDROID_HOME** to the Android SDK location.

    > Add or modify the environment variable **ANDROID_NDK_HOME** to the Android NDK location.

    > Modify the environment variable **PATH**, and add the **JDK tools** location. For example 'C:\Users\AppData\Local\Android\Sdk\tools'.

12. Click Ok.


## Setting up Unity3D to Build for Android
1. Open Unity and create a new project.

2. Once your new (or existing) project opens, we need to set it to build for Android. Go to **File > Build Settings**.

3. Select Android and then click **Switch Platform** on the bottom left. (If you did not add Android support when you first installed Unity, you will have to do so now, then restart Unity).

4. Close the Build Settings window and go to **Edit > Preferences**.

5. Click on the **External Tools** tab and scroll down to the **Android** section.

6. Set the SDK, JDK and NDK paths to what you copied to the text file in a previous step.

The following error message might appear.

[alt text](https://github.com/RobbeVermeire/BachelorClass2018/blob/master/Images/UnityNDKerror.PNG)

To resolve this you will have to follow these steps:
> 1. Click on the Download button next to the NDK field
> 2. Once the zip has finished download unpack the zip in your SDK root folder.
> 3. Remove all the contents of the 'ndk-bundle' folder and replace it with the new files from the folder you just unzipped.

7. Close the Preferences window and go to **Edit > Project Settings > Player**.

8. Scroll down to **XR Settings**. Click the box next to **Virtual Reality Supported**.

9. Verify that Oculus appears in the SDK's list. If not, click the “+” to the right, and select **Oculus**.

10. Scroll back up to the top and set your **Company Name** and **Product Name**.

11. Then scroll down to **Other** and set the Package Name field to **com.[CompanyName].[ProductName]**. For example: 'com.ArtesisPlantyn.myapp'.

12. Minimum API Level should be set to **API Level 21**.


## Import Oculus Samples Scenes
To get started with your app, we’ll import some premade sample scenes that Oculus was nice enough to make for us.
1. Grab the **OculusUtilities Unity package** that you downloaded before.

2. Drag and drop **OculusUtilities.unitypackage** into the Asset folders of your project, in the Unity window. Import when prompted.

3. Now, in your Assets folder, go to **Oculus > VR > Scenes**. Double click **GearVrControllerTest**.

4. In the hierarchy of the scene, dive down within the OVRCameraRig object to find the **OculusGoControllerModel** within the scene. Double click it to focus on it in the scene view.


## Enable Developer Mode on the Go
(Taken from the Oculus Developer documentation)

To begin development locally for Oculus Go, you must enable Developer Mode in the companion app. Before you can put your device in Developer Mode, you need to have created (or belong to) a developer organization on the [Oculus Dashboard](https://dashboard.oculus.com/).

To join an existing organization:
1. You’ll need to request access to the existing Organization from the admin.
2. You’ll receive an email invite. Once accepted, you’ll be a member of the Organization. 

To create a new organization:
1. Go to: https://dashboard.oculus.com/organization/create
2. Fill in the appropriate information.

To put your Oculus Go in developer mode:
1. Open the Oculus app on your mobile device.
2. In the Settings menu, select your Oculus Go headset that you’re using for development.
3. Select More Settings.
4. Toggle Developer Mode on.


## Set up Android Debug Bridge (ADB)
We’re almost done! Before we can actually move our Unity app from our computer to our Oculus GO, we need to install Android Debug Bridge (ADB) and the drivers for the Oculus Go.

Download and install the Oculus Go **ADB driver**:
1. Download [the zip file containing the driver](https://developer.oculus.com/downloads/package/oculus-go-adb-drivers/).
2. Unzip the file.
3. Right-click on the .inf file and select **Install**.


## Connect your Go and Build
1. Connect your go to your PC via micro-USB.

2. Go to Start Menu, search for CMD, right-click and open as Administrator.

3. Change your directory to the **platform-tools** folder of your root SDK folder. This is the installation folder of ADB. This will look something like this: 'C:\Users\YOURUSERNAME\AppData\Local\Android\sdk\platform-tools'.
```
    cd C:\Users\YOURUSERNAME\AppData\Local\Android\sdk\platform-tools
```

2. Now in the command prompt type the following:
```
    adb devices
```
to confirm that your Go has been detected.

3. Back in Unity, go to **File > Build Settings**.

4. Click “Add Open Scenes”, and ensure only the scene GearVrControllerTest has the check mark next to it checked. If it's not showing click the button “Add open Scenes”.

5. **Click Build**

6. Select the folder where you would like to place the .APK file that’s generated. I like to create a “Builds” folder in the project. **Save**.

7. After the .APK is generated, navigate to it in File Explorer. Copy it to the same directory where you installed ADB before.

8. Bring the command prompt back up.

9. Run:
```
    adb install [NameOfYourApp].apk
```

10. You should now see the file get transferred to your Oculus Go. In a minute or two, it should then show the message Success.

11. Now, to run your app, put on your Go and go to **Library > Unknown Sources**. You should see the Bundle ID of your app on the last page of the Unknown Apps list. Click on it to launch it.


## Updating / Uninstalling an Oculus Go application
Updating or debugging real time for your Oculus GO application isn't really straightforward. You will need to run the following command:
```
    adb uninstall [package name]
```
Where 'package name' is the same as you entered previously: **com.[Companyname].[Projectname]**.
If you then want to update your app just reïnstall it with the 'adb install' command we used before.
