using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlipperCurlUpsMinigame : MonoBehaviour
{
    [SerializeField] private float _minigameDuration = 15f;
    [SerializeField] private QTEBarUI _barQTE;
    [SerializeField] private GameObject _newRoundUI;
    [SerializeField] private TextMeshProUGUI _roundNumText;
    [SerializeField] private TextMeshProUGUI _bestOf3Text;
    
    [Space] 
    [SerializeField] private int _minEnemyRepCount = 4;
    [SerializeField] private int _maxEnemyRepCount = 8;

    private int roundNum = 1;
    private int roundsWon = 0;
    private bool roundStarted = false;
    private float minigameTimeElapsed = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartRound();
    }

    // Update is called once per frame
    void Update()
    {
        if (roundStarted)
        {
            minigameTimeElapsed += Time.deltaTime;
            if (minigameTimeElapsed >= _minigameDuration)
            {
                EndRound();
            }
        }
    }

    public void StartRound()
    {
        StartCoroutine(PlayNewRoundUI());
        roundNum++;
    }

    public IEnumerator PlayNewRoundUI()
    {
        _roundNumText.text = "ROUND " + roundNum;
        _bestOf3Text.text = "BEST OF 3 (" + roundsWon + "-" + (roundNum - roundsWon - 1) + ")";
        _newRoundUI.SetActive(true);
        
        yield return new WaitForSeconds(2);
        
        roundStarted = true;
        minigameTimeElapsed = 0f;
        
        _newRoundUI.SetActive(false);
        _barQTE.gameObject.SetActive(true);
    }

    public void EndRound()
    {
        roundStarted = false;

        int enemyRepCount = Random.Range(_minEnemyRepCount, _maxEnemyRepCount + 1);
        if (_barQTE.currentRepCount >= enemyRepCount)
        {
            roundsWon++;
        }

        if (roundsWon == 2)
        {
            // PLAYER WON
            LoadVictoryScene();
        }
        else if (roundNum == 3)
        {
            LoadDefeatScene();
        }
        else
        {
            _barQTE.ResetQTE();
            _barQTE.gameObject.SetActive(false);
            StartRound();
        }
    }

    private void LoadVictoryScene()
    {
        SceneManager.LoadScene("FlipperCurlUpVictory");
    }

    private void LoadDefeatScene()
    {
        SceneManager.LoadScene("FlipperCurlUpDefeat");
    }
}
