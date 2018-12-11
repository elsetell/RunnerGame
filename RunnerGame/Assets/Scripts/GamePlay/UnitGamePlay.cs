using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGamePlay : MonoBehaviour, IReturnToPool
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Action(other);
        }
    }
    protected virtual void Action(Collider other)
    {

    }
    public void ReturnToPool()
    {
        gameObject.SetActive(false);
    }
}
