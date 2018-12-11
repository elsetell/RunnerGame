using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputController : MonoBehaviour {
    [SerializeField]
    private PlayerSettings playerSettings;
    private bool move;
    public delegate void RefreshDistance();
    public RefreshDistance refreshDitance;

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
            refreshDitance();
        }
    }

    void MoveCharacter()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * playerSettings.speedMove);
    }

    void RotateCharacter()
    {
        float rotateX = Input.GetAxisRaw("Horizontal") * playerSettings.speedRotate;
        float angle = transform.localEulerAngles.y;
        angle = (angle > 180) ? angle - 360 : angle;
        if ((rotateX > 0 && angle < playerSettings.angleRotateMax) || (rotateX < 0 && angle > -playerSettings.angleRotateMax))
            transform.eulerAngles += new Vector3(0, rotateX, rotateX);
    }
}
