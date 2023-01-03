public class PowerUp_Magnet : PowerUps
{
    public override void PlayerCollided()
    {
        base.PlayerCollided();

        Player.Instance.PowerUpController.StartPowerUp_Magnet(_powerUpDuration);
    }
}