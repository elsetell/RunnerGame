using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    private CharacterInputController engine;
    private Vector3 startPos;

    private int distance;
    private int score;

    void RefreshDistance()
    {
        distance = (int)Vector3.Distance(transform.position, startPos);
        score = distance;
    }

    void Start()
    {
        engine = GetComponent<CharacterInputController>();
        startPos = transform.position;
        StartFly();
    }

    public void StartFly()
    {
        engine.StartEngine();
    }
}
