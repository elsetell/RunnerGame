using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Pool
{
    public string name;
    public GameObject prefab;
    public int size;
    public bool obstacle;
}

[CreateAssetMenu(menuName = "Game/PoolSettings", fileName = "PoolSettings")]
public class PoolSettings : ScriptableObject {
    public List<Pool> pools;
}
