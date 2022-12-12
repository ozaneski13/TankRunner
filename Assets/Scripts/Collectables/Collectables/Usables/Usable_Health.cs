using UnityEngine;

public class Usable_Health : Usables
{
    public override void Collected(GameObject tank)
    {
        base.Collected(tank);

        tank.GetComponent<Tank_Health>().IncreaseHealth();
    }
}