using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QTEBarUI : MonoBehaviour
{
    [Header("QTE Properties")] 
    [SerializeField] private KeyCode _qteKey;

    [SerializeField] private float _decreaseSpeed = 2f;
    [SerializeField] private float _finishedRepDecreaseSpeed = 120f;
    [SerializeField] private float _increaseAmount = 5f;
    [SerializeField] private int _repCount = 8;
    [SerializeField] private float _repTimerDuration = 1.25f;

    [Header("UI Components")] 
    [SerializeField] private Animator _animator;
    [SerializeField] private RectTransform _barUI;
    [SerializeField] private RectTransform _barMinimumRepMarker;
    [SerializeField] private TextMeshProUGUI _repCounter;
    [SerializeField] private AlembicController alembic;

    private float halfBarWidth;
    private float minimumRepPosition;
    private float minXPosition;
    private float maxXPosition;

    private float repTimeElapsed = 0f;
    public int currentRepCount = 0;

    private bool barDecreasing = false;
    
    private const string REP_TEXT = " REPS!";

    private void Start()
    {
        minimumRepPosition = _barMinimumRepMarker.anchoredPosition.x;
        halfBarWidth = _barUI.rect.size.x / 2;
        
        minXPosition = _barUI.anchoredPosition.x;
        maxXPosition = _barUI.anchoredPosition.x + _barUI.rect.size.x - 1;
    }

    private void Update()
    {
        UpdateBarPosition();
        UpdateRepTimer();
    }

    public void ResetQTE()
    {
        _barUI.anchoredPosition = new Vector2(-289f, _barUI.anchoredPosition.y);
        currentRepCount = 0;
    }

    private void UpdateRepTimer()
    {
        /*// Update rep timer
        float barPositionX = _barUI.anchoredPosition.x + halfBarWidth;
        if (barPositionX >= minimumRepPosition)
        {
            // If above the minimum rep progress, update the rep timer
            repTimeElapsed += Time.deltaTime;
            
            // If finished rep timer, do rep
            if (repTimeElapsed >= _repTimerDuration)
            {
                // Add rep count and reset timer
                AddRepCount();
                repTimeElapsed = 0f;
            }
        }
        else
        {
            repTimeElapsed = 0f;
        }*/
    }
    
    private void UpdateBarPosition()
    {
        if (barDecreasing)
        {
            float newXPosition = _barUI.anchoredPosition.x - (_finishedRepDecreaseSpeed * Time.deltaTime);
            if (newXPosition <= minXPosition)
            {
                barDecreasing = false;
            }
            
            newXPosition = Mathf.Max(newXPosition, minXPosition);

            _barUI.anchoredPosition = new Vector2(newXPosition, _barUI.anchoredPosition.y);
        }
        else
        {
            float newXPosition = _barUI.anchoredPosition.x;
            // Check for input
            if (Input.GetKeyDown(_qteKey))
            {
                // If input is pressed, bar gains progress
                newXPosition += _increaseAmount;

                if (newXPosition >= maxXPosition)
                {
                    AddRepCount();
                    barDecreasing = true;
                }
            }
            else
            {
                // If there is no input, bar loses progress
                newXPosition -= (_decreaseSpeed * Time.deltaTime);
            }
        
            // Clamp newXPosition
            newXPosition = Mathf.Min(newXPosition, maxXPosition);
            newXPosition = Mathf.Max(newXPosition, minXPosition);
        
            _barUI.anchoredPosition = new Vector2(newXPosition, _barUI.anchoredPosition.y);
        }
    }

    private void AddRepCount(int count = 1)
    {
        currentRepCount += count;
        alembic.repUpdate();
        UpdateRepCountUI();
    }

    private void UpdateRepCountUI()
    {
        _repCounter.text = currentRepCount + REP_TEXT;
        _animator.Play("UpdateRep");
    }
}
