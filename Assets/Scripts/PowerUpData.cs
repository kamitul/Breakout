using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PowerUpPropability
{
    public float Propability;
    public LootType LootType;
}

[CreateAssetMenu(fileName = "PowerUpData", menuName = "ScriptableObjects/PowerUpData", order = 1)]
public class PowerUpData : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField]
    private List<PowerUpPropability> powerUpData = default;

    private HashSet<PowerUpPropability> powerUpPropabilities = new HashSet<PowerUpPropability>();

    public HashSet<PowerUpPropability> PowerUpPropabilities { get => powerUpPropabilities; }

    public void OnAfterDeserialize()
    {
        powerUpPropabilities = new HashSet<PowerUpPropability>(powerUpData);
    }

    public void OnBeforeSerialize()
    {
    }
}
