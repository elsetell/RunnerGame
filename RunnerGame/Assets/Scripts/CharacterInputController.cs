﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputController : MonoBehaviour {
    private bool move;
    public float speedMove;
    public float speedRotate;
    public float angleRotateMax;

    public void StartEngine()
    {
        move = true;
    }
    public void StopEngine()
    {
        move = false;
    }

    void Update()
    {
        if(move)
        {
            MoveCharacter();
            RotateCharacter();
        }
    }

    void MoveCharacter()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speedMove);
    }

    void RotateCharacter()
    {
        float rotateX = Input.GetAxisRaw("Horizontal") * speedRotate;
        float angle = transform.localEulerAngles.y;
        angle = (angle > 180) ? angle - 360 : angle;
        if ((rotateX > 0 && angle < angleRotateMax) || (rotateX < 0 && angle > -angleRotateMax))
            transform.eulerAngles += new Vector3(0, rotateX, rotateX);
    }
}
