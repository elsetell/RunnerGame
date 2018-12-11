using UnityEngine;

public class Bonus : UnitGamePlay
{
    [SerializeField]
    private BonusSettings bonuSettings;
    protected override void Action(Collider other)
    {
        other.GetComponent<Character>().TakeBonus(bonuSettings.scoreAdd, (bonuSettings.invul) ? bonuSettings.invulSec : 0);
        GetComponent<Renderer>().enabled = false;
    }
}
