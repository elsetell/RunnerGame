using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControl : MonoBehaviour {
    private PoolObjects pool_manager;
    private int nCreatePlatform;
    private Transform character;
    private List<string> obstacleNames = new List<string>();

    public int maxPlatform;
    public int maxObstacle;

    private void Start()
    {
        pool_manager = GetComponent<PoolObjects>();
        GetNamesObstacle();
        character = GameObject.Find("Player").transform;
    }
    private void GetNamesObstacle()
    {
        foreach (Pool pool in pool_manager.pools)
            if (pool.obstacle)
                obstacleNames.Add(pool.name);
    }
    public void CreateMap()
    {
        for (int i = 0; i < maxPlatform; i++)
            CreatePlatform();
    }

    public void CreatePlatform()
    {
        GameObject platform = pool_manager.GetObject("Plane", new Vector3(character.position.x, -80, 300 * nCreatePlatform));
        if(nCreatePlatform != 0)
        {
            CreateObstacle(platform.transform);
        }
        nCreatePlatform++;
    }

    public void CreateObstacle(Transform platform)
    {
        if (obstacleNames.Count > 0)
        {
            float platformSizeX = platform.GetComponent<Collider>().bounds.size.x;
            float platformSizeZ = platform.GetComponent<Collider>().bounds.size.z;
            Platform parentObstacle = platform.GetComponent<Platform>();
            int max = maxObstacle;
            for (int i = 0; i < max; i++)
            {
                float x = platform.position.x + Random.Range(-platformSizeX / 2, platformSizeX / 2);
                float z = platform.position.z + Random.Range(-platformSizeZ / 2, platformSizeZ / 2);
                Vector3 posSpawn = new Vector3(x, 0, z);
                string nameObj = obstacleNames[Random.Range(0, obstacleNames.Count)];
                GameObject Zest = pool_manager.GetObject(nameObj, posSpawn);
                parentObstacle.obstacles.Add(Zest.GetComponent<IReturnToPool>());
            }
        }
    }
}
