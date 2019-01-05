using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TutorialManager : MonoBehaviour , IComparable<GameObject>, IComparer<GameObject>
{

    private GameObject[] slides;
    private List<GameObject> firstNr;

    public int firstNumb;
    

    private int incNext;
    private int prevSlide;

    void Start () {
        slides = GameObject.FindGameObjectsWithTag("Slide");
        firstNr = new List<GameObject>();

        foreach(GameObject slide in slides)
        {
            //slide.SetActive(false);
            //sort them here
            //Debug.Log("ob name: " + slide.name);
            firstNr.Add(slide);

            string name = slide.name;
            string firstPos = name.Substring(0, 1);
            firstNumb = int.Parse(firstPos);
        }

        firstNr.Sort();

        foreach(GameObject newSlide in firstNr)
        {
            Debug.Log("Arr list NOT sorted: " + newSlide);
        }

        slides[0].SetActive(true);

        incNext = 0;
        prevSlide = incNext;
	}
	
	public void NextSlide()
    {
        incNext++;

        slides[prevSlide].SetActive(false);
        slides[incNext].SetActive(true);

        prevSlide = incNext;
    }

    public int Compare(GameObject x, GameObject y)
    {
        string nameX = x.gameObject.name;
        string nameY = y.gameObject.name;

        string firstPosX = nameX.Substring(0, 1);
        string firstPosY = nameY.Substring(0, 1);

        int posX = int.Parse(firstPosX);
        int posY = int.Parse(firstPosY);

        if (posX > posY)
        {
            return 0;
        }
        return 1;
    }

    public int CompareTo(GameObject other)
    {
        return other.GetComponent<TutorialManager>().firstNumb.CompareTo(firstNumb);
    }
}
