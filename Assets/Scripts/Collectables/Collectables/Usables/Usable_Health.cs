using UnityEngine;

public class Usable_Health : Usables
{
    [SerializeField] private int _healthValue = 20;

    public override void PlayerCollided()
    {
        base.PlayerCollided();

        _player.Tank.TankHealth.IncreaseHealth(_healthValue);
    }
}