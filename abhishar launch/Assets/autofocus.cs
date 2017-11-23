using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class autofocus : MonoBehaviour {


    public CameraDevice.FocusMode mFocusMode = CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO;

    void Awake()
    {
        CameraDevice.Instance.SetFocusMode(mFocusMode);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
