using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour,IReturnToPool {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Character>().DestroyCharacter();
        }
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
    }
}
