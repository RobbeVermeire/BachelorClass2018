# Camera Effects in VR
Throughout this project we tried using all kinds of effects on the VR camera itself. 
Although it quickly became clear this wasen't all to evident because we are working with a camera wich get's updated constantly according to it's position in the real world.
So none of the camera effects really worked for our project. We will try to explain why.

Here are some things we tried adding in our project:

## Camera shake
Adding camera shake would be a very cool thing to add in a VR project. You can, for example, make the camera shake when a heavy object falls on the ground.
So we tried implementing this by briefly changing the **view angle and the position** of the camera. You can find the script under the “Kapoor project”.
Now this sounded like a valid solution it didn't work out as we wanted it to. In fact it didn't do anything at all.
To understand this you will need to understand how camera's work in Unity and for a VR platform like the VIVE or the Oculus Rift.
We couldn't figure it out but we think it has something to do with the way the VR camera get's initialised after the project is compiled.

## Camera fade-in and fade-out
Transitioning from one scene to another is always something important in game development. One easy way to do this is by adding a black fade in and fade out.
For our VR project we tried this by using the **UI component**, included in unity's engine, combined with **animations**, also a part of unity.
Now this kind of worked for the **htc VIVE** but not at all for the **Oculus GO**. You can find the script under the “Kapoor project”.
The problem with the htc VIVE was that when a scene transitions it briefly shows a different screen (probably steam VR Home) in between the transition.
We didn't want to waste any more time on this so we didn't bother to fix it. 
