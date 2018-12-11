using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour,IReturnToPool {

    public bool invul;
    public float invulSec;
    public int scoreAdd;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Character>().TakeBonus(scoreAdd, (invul) ? invulSec : 0);
            GetComponent<Renderer>().enabled = false;
        }
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
    }
}
