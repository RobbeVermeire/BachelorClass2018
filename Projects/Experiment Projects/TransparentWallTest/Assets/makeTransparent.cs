using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeTransparent : MonoBehaviour {


    Color color = new Color(0F,0F,0F, 1);
    Texture2D SliceGuideTex;
    Renderer ObjectRenderer;

    // Use this for initialization
    void Start () {
        ObjectRenderer = this.gameObject.GetComponent<Renderer>();
        SliceGuideTex = new Texture2D(16, 16);

        // set texture in the inspector slot
        ObjectRenderer.material.SetTexture("_SliceGuide", SliceGuideTex);

        // Fill the texture with white (you could also paint it black, then draw with white)
        for (int y = 0; y < SliceGuideTex.height; ++y) 
        {
            for (int x= 0; x < SliceGuideTex.width; ++x) 
            {
                SliceGuideTex.SetPixel(x, y, Color.white);
            }
        }
        // Apply all SetPixel calls
        SliceGuideTex.Apply();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.touchCount == 0 && !Input.anyKey) return;

        // Only if we hit something, do we continue
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out hit)) return;

        // Just in case, also make sure the collider also has a renderer
        // material and texture. Also we should ignore primitive colliders.
        Renderer renderer = hit.collider.gameObject.GetComponent<Renderer>();

        var meshCollider = hit.collider as MeshCollider;
        if (renderer == null || renderer.sharedMaterial == null || SliceGuideTex == null || meshCollider == null) return;

        // Now draw a pixel where we hit the object
        Texture2D tex = SliceGuideTex;
        var pixelUV = hit.textureCoord;
        pixelUV.x *= tex.width;
        pixelUV.y *= tex.height;

        // add black spot, which is then transparent in the shader
        tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.black);
        tex.Apply();

    }
}
