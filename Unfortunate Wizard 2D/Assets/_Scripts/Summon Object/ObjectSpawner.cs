using UnityEngine;
using UnityUtils;

public class ObjectSpawner : Singleton<ObjectSpawner>
{

    private SummonObjectData currentObject;
    [SerializeField] private SummonObjectsDataSO summonObjectsData;
    [SerializeField] private IndicatorUI indicator;
    private Camera mainCamera;

    protected override void Awake()
    {
        base.Awake();
        mainCamera = Camera.main;
    }

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
        if (indicator.IsVisible)
        {
            Instantiate(currentObject.prefab, GetMousePosition().With(z: 0), RotationHelper.RotationToQuaternion());
        }
    }
    
    private void SetCurrentObject(CardInfo cardInfo)
    {
        currentObject = summonObjectsData.GetSummonObjectData(cardInfo.summonObjectId);
        indicator.SetIndicatorObject(currentObject.prefab);
    }

    private Vector3 GetMousePosition()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

}