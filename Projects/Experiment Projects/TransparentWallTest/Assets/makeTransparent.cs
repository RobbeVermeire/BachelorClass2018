using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeTransparent : MonoBehaviour {



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (!Input.GetMouseButton(0))
            return;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Renderer renderer = hit.collider.GetComponent<Renderer>();
            MeshCollider meshCollider = hit.collider as MeshCollider;
            Texture2D tex = (Texture2D)renderer.material.mainTexture;

            Vector2 vec = new Vector2(tex.width, tex.height);

            Debug.Log(hit.textureCoord*vec);
        }

    }
}
