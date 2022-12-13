public class PowerUp_Buldozer : PowerUps
{
    public override void CollectableCollected()
    {
        base.CollectableCollected();

        _player.PowerUpController.StartPowerUp_Buldoze(_powerUpDuration);
    }
}