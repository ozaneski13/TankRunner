using UnityEngine;

public class PowerUp_Fire : PowerUps
{
    [Header("Fire Settings")]
    [SerializeField] private int _fireCount = 3;

    public override void PlayerCollided()
    {
        base.PlayerCollided();

        _player.PowerUpController.StartPowerUp_Fire(_fireCount, _powerUpDuration);
    }
}