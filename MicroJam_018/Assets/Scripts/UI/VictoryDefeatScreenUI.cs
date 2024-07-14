using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryDefeatScreenUI : MonoBehaviour
{
    [SerializeField] private string _restartScene = "";
    [SerializeField] private string _nextMinigameScene = "";

    public void LoadRestart()
    {
        SceneManager.LoadScene(_restartScene);
    }

    public void LoadNextMinigame()
    {
        SceneManager.LoadScene(_nextMinigameScene);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
