using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private string firstMinigameScene = "FlipperCurlUp";

    public void Play()
    {
        SceneManager.LoadScene(firstMinigameScene);
    }
}
