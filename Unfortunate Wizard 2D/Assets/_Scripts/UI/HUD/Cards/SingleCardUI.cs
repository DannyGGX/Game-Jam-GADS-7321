using UnityEngine;
using TMPro;

public class SingleCardUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private SummonObjectsDataSO summonObjectsData;
    
    
    public void SetCardUI(CardInfo cardInfo)
    {
        SummonObjectData data = summonObjectsData.GetSummonObjectData(cardInfo.summonObjectId);
        
        cardName.text = data.name.ReplaceUnderscoreWithSpace();
        
    }
    
    
}