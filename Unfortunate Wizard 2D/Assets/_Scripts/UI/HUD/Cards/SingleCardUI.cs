using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SingleCardUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private SummonObjectsDataSO summonObjectsData;
    [SerializeField, Tooltip("In child object")] private CardSelectionUI cardSelectionUI;
    private bool _isSelected;

    private CardInfo _currentCard;

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(OnCardClicked);
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveListener(OnCardClicked);
    }

    private void OnCardClicked()
    {
        if (_isSelected)
        {
            EventManager.onCardDeselected.Invoke();
            _isSelected = false;
        }
        else
        {
            EventManager.onCardSelected.Invoke(_currentCard);
            _isSelected = true;
        }
        cardSelectionUI.ChangeCardSelectionState(_isSelected);
    }
    
    
    public void SetCardUI(CardInfo cardInfo)
    {
        _currentCard = cardInfo;
        SummonObjectData data = summonObjectsData.GetSummonObjectData(cardInfo.summonObjectId);
        
        cardName.text = data.name.ReplaceUnderscoreWithSpace();
        
    }
    
}