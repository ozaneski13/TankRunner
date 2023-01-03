using UnityEngine;

public class PowerUp_Jump : PowerUps
{
    [Header("Jump Settings")]
    [SerializeField] private int _jumpCount = 5;

    public override void PlayerCollided()
    {
        base.PlayerCollided();

        Player.Instance.PowerUpController.StartPowerUp_Jump(_jumpCount, _powerUpDuration);
    }
}