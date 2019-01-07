using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumppadActivation : MonoBehaviour {

    private GameObject[] jump_pads;
    private GameObject btnJumpPad;

    private bool isPadActive;

	void Start ()
    {
        btnJumpPad = GameObject.Find("Jump pad activtion");
        jump_pads  = GameObject.FindGameObjectsWithTag("Jump_pad");

        PadActivationConfiguration(true, "Jump pad: ON", Color.green);
	}

    void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            PadActivation();
        }
    }
	
	public void PadActivation()
    {
        if (isPadActive == true)
        {
            PadActivationConfiguration(false, "Jump pad: OFF", Color.red);
        }
        else if (isPadActive == false)
        {
            PadActivationConfiguration(true, "Jump pad: ON", Color.green);
        }
    }
    private void PadActivationConfiguration(bool padCondition, string btnTxt, Color btnColor)
    {
        isPadActive = padCondition;
        btnJumpPad.GetComponentInChildren<Text>().text = btnTxt;
        btnJumpPad.transform.GetChild(0).GetComponent<Image>().color = btnColor;
        foreach (GameObject jump_pad in jump_pads)
        {
            jump_pad.SetActive(padCondition);
        }
    }
}
