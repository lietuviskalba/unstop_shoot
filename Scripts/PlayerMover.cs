using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : Character {

    public bool isShootingStoped;

    void FixedUpdate()
    {
        NavigationButtons();
    }

    private void NavigationButtons()
    {
        if (Input.GetKey("a"))
        {
            ChangeDirGS = -1;
        }
        else if (Input.GetKey("d"))
        {
            ChangeDirGS = 1;
        }
    }

    public void TouchNavigation(float dir)
    {
        ChangeDirGS = dir;
    }
}