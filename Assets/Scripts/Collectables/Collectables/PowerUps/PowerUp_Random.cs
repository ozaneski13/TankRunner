using UnityEngine;

public class PowerUp_Random : PowerUps
{
    [SerializeField] private int _powerUpUseCount = 5;

    public override void PlayerCollided()
    {
        base.PlayerCollided();

        int randomPowerUp = Random.Range(0, 4);

        if(randomPowerUp == 0 )
            _player.PowerUpController.StartPowerUp_Buldoze(_powerUpDuration);
        if (randomPowerUp == 0)
            _player.PowerUpController.StartPowerUp_Magnet(_powerUpDuration);
        if (randomPowerUp == 0)
            _player.PowerUpController.StartPowerUp_Fire(_powerUpUseCount, _powerUpDuration);
        if (randomPowerUp == 0)
            _player.PowerUpController.StartPowerUp_Jump(_powerUpUseCount, _powerUpDuration);
    }
}