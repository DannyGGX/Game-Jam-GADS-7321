using System;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField, Tooltip("Ordered from left to right")] private SingleCardUI[] singleCardUI = new SingleCardUI[3];
    private int numberOfCardsInHand;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        EventManager.onDrawCards.Subscribe(DrawNewCards);
        EventManager.onSpawnObject.Subscribe(CardUsed);
    }
    private void OnDisable()
    {
        EventManager.onDrawCards.Unsubscribe(DrawNewCards);
        EventManager.onSpawnObject.Unsubscribe(CardUsed);
    }

    private void Init()
    {
        numberOfCardsInHand = singleCardUI.Length;
    }
    
    private void DrawNewCards(CardInfo[] cardsInfo)
    {
        for (int i = 0; i < cardsInfo.Length; i++)
        {
            singleCardUI[i].SetCardUI(cardsInfo[i]);
            singleCardUI[i].gameObject.SetActive(true);
        }
    }
    
    private void CardUsed(CardInfo cardInfo)
    {
        singleCardUI[cardInfo.cardId].gameObject.SetActive(false);
        
        numberOfCardsInHand--;
        if (numberOfCardsInHand <= 0)
        {
            EventManager.onHandEmpty.Invoke();
        }
    }
}