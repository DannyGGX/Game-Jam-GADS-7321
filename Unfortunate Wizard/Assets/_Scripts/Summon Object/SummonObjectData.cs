using System;
using UnityEngine;
using NaughtyAttributes;

[Serializable]
public class SummonObjectData
{
    [field: SerializeField, Tooltip("For showing on the cards")] public string name { get; set; }
    public int id { get; set; }
    [field: SerializeField, ShowAssetPreview] public BaseSummonObject prefab { get; set; }
    [field: SerializeField, Range(0, 5000), Tooltip("In kg")] public float mass { get; set; }
    [field: SerializeField] public Vector2 centerOfMassDisplacement { get; set; }

    public SummonObjectData(string name, int id, BaseSummonObject prefab, float mass, Vector2 centerOfMassDisplacement)
    {
        this.name = name;
        this.id = id;
        this.prefab = prefab;
        this.mass = mass;
        this.centerOfMassDisplacement = centerOfMassDisplacement;
    }
    
    
}