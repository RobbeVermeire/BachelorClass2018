using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ViveInput : MonoBehaviour {

    void Update()
    {
        if (SteamVR_Input._default.GrabPinch.GetStateDown(SteamVR_Input_Sources.Any))
            print("Grab Pinch Down");
    }
}
