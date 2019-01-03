using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumppadActivation : MonoBehaviour {

    private GameObject[] jump_pads;
    public Button btnJumpPad;

    private bool isPadActive;

	void Start () {

        jump_pads = GameObject.FindGameObjectsWithTag("Jump_pad");
        PadActivationConfiguration(true, "Jump pad: ON", Color.green);
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
        btnJumpPad.GetComponent<Image>().color = btnColor;
        foreach (GameObject jump_pad in jump_pads)
        {
            jump_pad.SetActive(padCondition);
        }
    }
}
