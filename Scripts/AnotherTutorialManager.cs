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

        //Set all of the slides off at start
        for (int i = 0; i < childCount; i++)
        {
            children[i] = parent.GetChild(i);
            children[i].gameObject.SetActive(false);
        }
        //Keep active only the first slide at start
        children[0].gameObject.SetActive(true);
    }
	
	public void NextSlide()
    {
        try
        {
            incIndex++;
            children[incIndex].gameObject.SetActive(true); //Activate next slide
            children[prevIndex].gameObject.SetActive(false); //Disable prev slide
            prevIndex = incIndex; //Set the prev slide with the curr index, before inc
        }
        catch(Exception)
        {
            //Before running out of index in the array. Go back to menu.
            LevelManager lm = gameObject.AddComponent<LevelManager>();
            lm.LoadStartScene();
        }
    }
}
