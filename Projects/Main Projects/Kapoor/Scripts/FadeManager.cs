using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour {

	public static FadeManager Instance { get; set; }



    private void Awake()
    {
        Instance = this;
    }
}
