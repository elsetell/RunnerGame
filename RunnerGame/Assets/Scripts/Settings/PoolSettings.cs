using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Pool
{
    public string name;
    public GameObject prefab;
    public int size;
}

[CreateAssetMenu(menuName = "Game/PoolSettings", fileName = "PoolSettings")]
public class PoolSettings : ScriptableObject {
    public List<Pool> pools;
}
