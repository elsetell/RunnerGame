using UnityEngine;

[CreateAssetMenu(menuName = "Game/PlayerSettings", fileName = "PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    [Range(15.0f, 35.0f)] public float angleRotateMax;
    [Range(1.0f, 75.0f)] public float speedMove;
    [Range(0.5f, 5.0f)] public float speedRotate;
}
