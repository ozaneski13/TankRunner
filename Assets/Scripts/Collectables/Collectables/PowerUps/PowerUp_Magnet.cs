public class PowerUp_Magnet : PowerUps
{
    public override void PlayerCollided()
    {
        base.PlayerCollided();

        _player.PowerUpController.StartPowerUp_Magnet(_powerUpDuration);
    }
}