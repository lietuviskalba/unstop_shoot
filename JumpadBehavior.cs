using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpadBehavior : MonoBehaviour {

    private float jumpDelay;
    private float nextJump;
    private bool hasSteppedOnPad;

    void Start () {
        jumpDelay = 0.2f;
        hasSteppedOnPad = false;
	}

    void OnTriggerEnter(Collider other)
    {



        
    }

    public void SetLaunchReady(bool hasStepped)
    {
        hasSteppedOnPad = hasStepped;
    }
    
    public bool GetLaunchReady()
    {
        return hasSteppedOnPad;
    }
}
