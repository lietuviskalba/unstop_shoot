using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text txtScore;
    public GameObject tint;

    public static int score;
    public int goalScore;

    public static bool hasWon;
    public static bool hasLost;

	void Start () {

        tint.SetActive(false);

        hasWon = false;
        hasLost = false;
        score = 0;

        DisplayScore();
	}
	
	void Update ()
    {
        DisplayScore();
        WinLoseConditions();
    }

    private void WinLoseConditions()
    {
        if (hasLost == true && hasWon == false)
        {
            EndLevelCard("GAME OVER \n(Reset Level)", Color.red);
        }

        if (score >= goalScore && hasLost == false)
        {
            hasWon = true;
            EndLevelCard("Level passed \n(Next Level)", Color.green);
        }
    }

    public void ClickNextChoice()
    {
        LevelManager lm = gameObject.AddComponent<LevelManager>();

        if (hasWon == true)
        {
            hasWon = false;
            hasLost = false;
            lm.LoadNextLevel();
        }
        if (hasLost == true)
        {
            hasWon = false;
            hasLost = false;
            lm.RestartGame();
        }
    }

    private void EndLevelCard(string message, Color color)
    {
        tint.SetActive(true);
        tint.GetComponentInChildren<Text>().text = message;
        tint.GetComponentInChildren<Text>().color = color;       
    }

    private void DisplayScore()
    {
        txtScore.text = "Score: " + score.ToString() + "/" + goalScore.ToString();
    }

}
