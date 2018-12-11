using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour, IReturnToPool {
    public List<IReturnToPool> obstacles = new List<IReturnToPool>();

    public void ReturnToPool()
    {
        foreach (IReturnToPool obstacle in obstacles)
            obstacle.ReturnToPool();
        obstacles.Clear();
        gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Character>().createPlatform();
            ReturnToPool();
        }
    }
}
