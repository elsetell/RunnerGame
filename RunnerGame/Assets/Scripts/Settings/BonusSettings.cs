using UnityEngine;

[CreateAssetMenu(menuName = "Game/BonusSettings", fileName = "BonusSettings")]
public class BonusSettings : ScriptableObject
{
    public int scoreAdd;
    public bool invul;
    public float invulSec;
}
