public class Usable_Health : Usables
{
    public override void PlayerCollided()
    {
        base.PlayerCollided();

        _player.Tank.TankHealth.IncreaseHealth();
    }
}