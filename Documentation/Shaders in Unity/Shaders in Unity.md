# Shaders in Unity
## Materials, Textures & Shaders
Rendering in Unity uses <b>Materials, Textures & Shaders</b>. They work together to render objects on the screen.  
<b>Textures</b> are bitmap images, they define what has to be rendered on an object. It can represent not only the basic colors of an object, but also the roughness or reflectivity of a material's surface.  
A <b>material</b> is made with a reference to a texture, materials also define how the texture should be tiled, color tints and more.  
<b>Shaders</b> are scripts that define how each pixel of the material should be rendered by the GPU. In Unity these scripts are files with the '.shader' file format, they look something like this:  
![Example Shader](https://github.com/RobbeVermeire/BachelorClass2018/blob/master/Images/ShaderExample.png)

## Shader Syntax
Shaders are written in ShaderLab Syntax, it's a declarative wrapper language. It defines what shader properties should be used, hardware fallbacks and also the actual shader program. The actual shader code is written in the `CGPROGRAM` - `ENDCG` part of the code. The shader code is written in HLSL/CG.
All shaders are written in the same structure, which the <b>ShaderLab-Syntax</b> defines:  

`Shader "name" { [Properties] __Subshaders__ [Fallback] [CustomEditor] }`  

Firstly a `Shader` is defined with name `name`, optionally some properties can be defined for the shader. Then a list of subshaders is defined, you need at least 1 for the shader to work, this is where u write the shader code. Unity goes though this list of subshaders when the shader is loaded, when no subshader is supported by the users machine if goes to the `[Fallback]` shader. Subshaders give you the flexibility of making your program <b>look good</b> on high end computers and still <b>run them</b> on low end computers.

## Shader example
Lastly we will go over a shader file and explain what every part does. We've taken the holes shader from our Panamarenco project as an example:  
![Holes Shader](https://github.com/RobbeVermeire/BachelorClass2018/blob/master/Images/HolesShader.png)

As you can see, this shader follows the ShaderLab-Syntax: It defines a shader, the properties of the shader, 1 subshader and a Fallback shader.
The properties that are defined are 2 2DTextures `_MainText` & `_SliceGuide` and a _SliceAmount float which acts as a threshhold-value. You can access these properties from the Unity editor and change them.

This shader is used to erase parts of textures dynamically by the user by pointing the vive controller and pressing a button. Doing this will set the `_SliceGuide` texture to black. Then the renderer will check what pixels from the `_SliceGuide`-textures are black, if they're black they won't be rendered.
The check is performed by the clip()-function. It will look at all the pixels seperatly, check if the rgb value is bigger than the `_SliceAmount` threshhold value. If it is, the pixel is rendered if not the pixel is not rendered.

