using UnityEngine;
using UnityUtils;

public class ObjectSpawner : Singleton<ObjectSpawner>
{
    
    private SummonObjectData currentObject;
    private SummonObjectsDataSO summonObjectsData;
    private IndicatorUI indicator;
    
    private void OnEnable()
    {
        EventManager.onIndicatorRotate.Subscribe(RotationHelper.ChangeRotation);
        EventManager.onCardSelected.Subscribe(SetCurrentObject);
        EventManager.onSpawnObject.Subscribe(SpawnObject);
    }

    private void OnDisable()
    {
        EventManager.onIndicatorRotate.Unsubscribe(RotationHelper.ChangeRotation);
        EventManager.onCardSelected.Unsubscribe(SetCurrentObject);
        EventManager.onSpawnObject.Unsubscribe(SpawnObject);
    }
    
    private void SpawnObject(CardInfo cardInfo)
    {
        CreateObject();
    }
    
    private void CreateObject()
    {
        GameObject.Instantiate(currentObject.prefab, GetMousePosition(), RotationHelper.RotationToQuaternion());
    }
    
    private void SetCurrentObject(CardInfo cardInfo)
    {
        currentObject = summonObjectsData.GetSummonObjectData(cardInfo.summonObjectId);
        indicator.SetIndicatorObject(currentObject.prefab);
    }

    

    private Vector3 GetMousePosition()
    {
        // get mouse position
        return Input.mousePosition;
    }

}