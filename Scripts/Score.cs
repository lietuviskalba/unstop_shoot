using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text txtScore;

    public static int score;
    public int goalScore;

	void Start () {

        score = 0;

        DisplayScore();
	}
	
	void Update ()
    {
        DisplayScore();

        if (score >= goalScore)
        {
            // load new scene
            Debug.Log("Next level WIN");

        }
    }

    private void DisplayScore()
    {
        txtScore.text = "Score: " + score.ToString() + "/" + goalScore.ToString();
    }

}
