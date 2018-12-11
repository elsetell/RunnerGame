using UnityEngine;

[CreateAssetMenu(menuName = "Game/MapSettings", fileName = "MapSettings")]
public class MapSettings : ScriptableObject{
    public int maxPlatform;
    public int maxBonus;//in 1 platform
    [Range(0, 10)]
    public int maxObstacle;//in 1 platform
}
