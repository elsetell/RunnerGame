using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public string name;
    public GameObject prefab;
    public int size;
    public bool obstacle;
}
public class PoolObjects : MonoBehaviour {
    public List<Pool> pools;
    private Dictionary<string, List<GameObject>> poolDict;
    private Transform objectsParent;

    void Start()
    {
        CreatePool();
    }

    public void CreatePool()
    {
        poolDict = new Dictionary<string, List<GameObject>>();
        objectsParent = new GameObject("Pool").transform;
        foreach (Pool pool in pools)
        {
            List<GameObject> objectPool = new List<GameObject>();
            poolDict.Add(pool.name, objectPool);

            for (int i = 0; i < pool.size; i++)
            {
                AddObject(pool);
            }
        }
    }
    public GameObject AddObject(Pool pool)
    {
        GameObject obj = Instantiate(pool.prefab);
        obj.SetActive(false);
        poolDict[pool.name].Add(obj);
        obj.transform.SetParent(objectsParent);
        return obj;
    }
    public GameObject AddObject(string name)
    {
        Pool pool = GetPoolByName(name);
        return (pool != null) ? AddObject(pool) : null;
    }

    public GameObject GetObject(string name, Vector3 pos)
    {
        if (!poolDict.ContainsKey(name))
            return null;
        GameObject objectToSpawn = GetObjectOfPool(name);
        objectToSpawn.transform.position = pos;
        objectToSpawn.SetActive(true);
        return objectToSpawn;
    }

    private Pool GetPoolByName(string name)
    {
        foreach (Pool pool in pools)
            if (pool.name == name)
                return pool;
        return null;
    }
    private GameObject GetObjectOfPool(string name)
    {
        foreach (GameObject obj in poolDict[name])
            if (!obj.activeInHierarchy)
                return obj;
        return AddObject(name);
    }
}
