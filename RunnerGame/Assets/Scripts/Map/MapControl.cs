using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControl : MonoBehaviour {
    private PoolObjects pool_manager;
    private int nCreatePlatform;

    public int maxPlatform;

    private void Start()
    {
        pool_manager = GetComponent<PoolObjects>();
    }

    public void CreateMap()
    {
        for (int i = 0; i < maxPlatform; i++)
            CreatePlatform();
    }

    public void CreatePlatform()
    {
        GameObject platform = pool_manager.GetObject("Plane", new Vector3(0, -80, 300 * nCreatePlatform));
        nCreatePlatform++;
    }
}
