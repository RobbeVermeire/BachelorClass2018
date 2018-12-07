using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutTriangle : MonoBehaviour {

    public Texture2D sourceTex;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {

                deleteTriangle(hit.triangleIndex);

            }
        
		
	}

    private void makePixelTransparent()
    {
        sourceTex = this.gameObject.GetComponent<Texture2D>();

    }

    private void deleteTriangle(int triangleIndex)
    {
        Destroy(this.gameObject.GetComponent<MeshCollider>());
        Mesh mesh = transform.GetComponent<MeshFilter>().mesh;
        int[] oldTriangles = mesh.triangles;
        int[] newTriangles = new int[oldTriangles.Length - 3];

        int i = 0;
        int j = 0;

        while(j < mesh.triangles.Length)
        {
            if (j != triangleIndex*3)
            {
                newTriangles[i++] = oldTriangles[j++];
                newTriangles[i++] = oldTriangles[j++];
                newTriangles[i++] = oldTriangles[j++];
            }
                
            else
            {

                j += 3;
            }
        }
        transform.GetComponent<MeshFilter>().mesh.triangles = newTriangles;
        this.gameObject.AddComponent<MeshCollider>();
    }
}
