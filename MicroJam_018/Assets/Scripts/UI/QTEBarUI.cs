using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEBarUI : MonoBehaviour
{
    [Header("QTE Properties")] 
    [SerializeField] private KeyCode _qteKey;

    [SerializeField] private float _decreaseSpeed = 2f;
    [SerializeField] private float _increaseAmount = 5f;
    
    [Header("UI Components")]
    [SerializeField] private RectTransform _barUI;
    
    private float minXPosition;
    private float maxXPosition;

    private void Start()
    {
        minXPosition = _barUI.anchoredPosition.x;
        maxXPosition = _barUI.anchoredPosition.x + _barUI.rect.size.x - 1;
    }

    private void Update()
    {
        UpdateBarPosition();
    }

    private void UpdateBarPosition()
    {
        // Check for input
        if (Input.GetKeyDown(_qteKey))
        {
            // If input is pressed, bar gains progress
            float newXPosition = _barUI.anchoredPosition.x + _increaseAmount;
            
            _barUI.anchoredPosition = new Vector2(newXPosition, _barUI.anchoredPosition.y);
        }
        else
        {
            // If there is no input, bar loses progress
            float newXPosition = _barUI.anchoredPosition.x - (_decreaseSpeed * Time.deltaTime);
            
            // Clamp newXPosition
            newXPosition = Mathf.Min(newXPosition, maxXPosition);
            newXPosition = Mathf.Max(newXPosition, minXPosition);
            
            _barUI.anchoredPosition = new Vector2(newXPosition, _barUI.anchoredPosition.y);
        }
    }
}
