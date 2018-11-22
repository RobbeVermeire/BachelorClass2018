using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSourceScript : MonoBehaviour {

    GameObject lightGameObject;
    Light lightComp;
    bool test = true;
    // Use this for initialization
    void Start () {
        transform.
        lightGameObject = new GameObject("Light");
        lightComp = lightGameObject.AddComponent<Light>();
        lightComp.color = Color.red;
	}
	


	// Update is called once per frame
	void Update () {


        lightGameObject.transform.Translate(Vector3.right);
    }
}
