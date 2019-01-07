using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private GameObject endLvlCard;
    private Text txtScore;

    public static int score;
    public int goalScore;

    public static bool hasWon;
    public static bool hasLost;

	void Start () {

        endLvlCard = GameObject.Find("End level card");
        txtScore = GameObject.Find("Score").GetComponent<Text>();

        endLvlCard.SetActive(false);
        SetWinLossGameState(false);

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
            SetWinLossGameState(false);
            lm.LoadNextLevel();
        }
        if (hasLost == true)
        {
            SetWinLossGameState(false);
            lm.RestartGame();
        }
    }

    private static void SetWinLossGameState(bool state)
    {
        hasWon = state;
        hasLost = state;
    }

    private void EndLevelCard(string message, Color color)
    {
        endLvlCard.SetActive(true);
        endLvlCard.GetComponentInChildren<Text>().text = message;
        endLvlCard.GetComponentInChildren<Text>().color = color;       
    }

    private void DisplayScore()
    {
        txtScore.text = "Score: " + score.ToString() + "/" + goalScore.ToString();
    }

}
