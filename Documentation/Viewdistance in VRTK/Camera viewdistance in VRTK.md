## View distance in VRTK VR simulator

### Introduction
The far and short clipping plane set the view distance of a camera object in unity. Far clipping plane sets max view distance and short clipping minimal view distance. When you are developing with a VR brill, like the htc vive, the camera rigg will contain a camera object. You can easily adjust the clipping planes of this camera object, hereby setting the max and min view distance of the viewer looking trough the VR brill.

When you are developing with the VRTK VR simulator, this isn't so easy to adjust. Unfortunately the camerarig of the simulator doesn't contain a camera object. 
The default far clipping plane of the VRTK VR simulator camerarig is 1000.

### Proposed solution
Adding a camera object to the VRTK camerarig, so we can adjust the far clipping plane. This works, but, you can no longer look up or down in the simulator. 

The best solution, I think, is to work on a smaller scale, so you won't have to see further than 1000 units in Unity.
