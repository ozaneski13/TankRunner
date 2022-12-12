using UnityEngine;

public class PowerUp_Jump : PowerUps
{
    [SerializeField] private int _jumpCount = 5;

    public override void Collected(GameObject tank)
    {
        base.Collected(tank);
    }
}