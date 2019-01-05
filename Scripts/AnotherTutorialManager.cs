using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherTutorialManager : MonoBehaviour {

    public GameObject slides;

    Transform parent;
    Transform[] children;

    int childCount;
    int incIndex;
    int prevIndex;

	void Start () {

        parent = slides.transform;
        childCount = parent.childCount;
        children = new Transform[childCount];  

        incIndex = 0;
        prevIndex = incIndex;

        for (int i = 0; i < childCount; i++)
        {
            children[i] = parent.GetChild(i);
            children[i].gameObject.SetActive(false);
        }

        children[0].gameObject.SetActive(true);
    }
	
	public void NextSlide()
    {
        try
        {
            incIndex++;
            children[incIndex].gameObject.SetActive(true);
            children[prevIndex].gameObject.SetActive(false);
            prevIndex = incIndex;
        }
        catch(Exception e)
        {
            LevelManager lm = gameObject.AddComponent<LevelManager>();
            lm.LoadStartScene();
        }
        

        
    }
}
