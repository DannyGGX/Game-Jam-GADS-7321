using UnityEngine;
using UnityUtils;

public class CardDrawer : Singleton<CardDrawer>
{
    [SerializeField] private SummonObjectsForLevelSO currentlevelSummonObjects;
    
    public CardInfo[] DrawCards(int numberOfCards = 3)
    {
        CardInfo[] cardsInfo = new CardInfo[numberOfCards];
        for (int currentCard = 0; currentCard < numberOfCards; currentCard++)
        {
            cardsInfo[currentCard] = new CardInfo(currentlevelSummonObjects.GetRandomSummonObject(), currentCard);
        }
        return cardsInfo;
    }
}