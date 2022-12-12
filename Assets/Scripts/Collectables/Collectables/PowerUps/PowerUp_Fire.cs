using UnityEngine;

public class PowerUp_Fire : PowerUps
{
    [SerializeField] private int _fireCount = 3;

    public override void Collected(GameObject tank)
    {
        base.Collected(tank);
    }
}