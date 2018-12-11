using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : UnitGamePlay {

    protected override void Action(Collider other)
    {
        other.GetComponent<Character>().DestroyCharacter();
    }
}
