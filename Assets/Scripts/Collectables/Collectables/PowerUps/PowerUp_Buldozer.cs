public class PowerUp_Buldozer : PowerUps
{
    public override void PlayerCollided()
    {
        base.PlayerCollided();

        Player.Instance.PowerUpController.StartPowerUp_Buldoze(_powerUpDuration);
    }
}