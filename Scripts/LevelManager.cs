using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadNextLevel()
    {
        int currSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currSceneIndex + 1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void QuiteGame()
    {
        Application.Quit();
    }
}
