using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PoolObjects))]
public class MapControl : MonoBehaviour {
    [SerializeField]
    private MapSettings mapSettings;
    private PoolObjects pool_manager;
    private int nCreatePlatform;
    private Transform character;
    private List<string> obstacleNames = new List<string>();

    private void Start()
    {
        pool_manager = GetComponent<PoolObjects>();
        GetNamesObstacle();
        character = GameObject.FindWithTag("Player").transform;
    }

    private void GetNamesObstacle()
    {
        foreach (Pool pool in pool_manager.poolSettings.pools)
            if (pool.prefab.GetComponent<UnitGamePlay>() is Obstacle)
                obstacleNames.Add(pool.name);
    }
    public void CreateMap()
    {
        for (int i = 0; i < mapSettings.maxPlatform; i++)
            CreatePlatform();
    }

    public void CreatePlatform()
    {
        GameObject platform = pool_manager.GetObject("Plane", new Vector3(character.position.x, -20, 300 * nCreatePlatform));
        if(nCreatePlatform != 0)
        {
            CreateZest(platform.transform, true);
            CreateZest(platform.transform, false);
        }
        nCreatePlatform++;
    }

    public void CreateZest(Transform platform, bool obstacle) //create obstacle(true) or bonus(false)
    {
        if (obstacleNames.Count > 0)
        {
            float platformSizeX = platform.GetComponent<Collider>().bounds.size.x;
            float platformSizeZ = platform.GetComponent<Collider>().bounds.size.z;
            Platform parentObstacle = platform.GetComponent<Platform>();
            int max = (obstacle) ? mapSettings.maxObstacle : mapSettings.maxBonus;
            for (int i = 0; i < max; i++)
            {
                float x = platform.position.x + Random.Range(-platformSizeX / 2, platformSizeX / 2);
                float z = platform.position.z + Random.Range(-platformSizeZ / 2, platformSizeZ / 2);
                Vector3 posSpawn = new Vector3(x, 0, z);
                string nameObj = (obstacle) ? obstacleNames[Random.Range(0, obstacleNames.Count)] : "Bonus";
                GameObject Zest = pool_manager.GetObject(nameObj, posSpawn);
                parentObstacle.obstacles.Add(Zest.GetComponent<IReturnToPool>());
            }
        }
    }
}
