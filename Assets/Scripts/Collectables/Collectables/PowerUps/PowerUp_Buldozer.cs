public class PowerUp_Buldozer : PowerUps
{
    public override void PlayerCollided()
    {
        base.PlayerCollided();

        _player.PowerUpController.StartPowerUp_Buldoze(_powerUpDuration);
    }
}