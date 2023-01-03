using UnityEngine;

public class PowerUp_Random : PowerUps
{
    [SerializeField] private int _powerUpUseCount = 5;

    public override void PlayerCollided()
    {
        base.PlayerCollided();

        int randomPowerUp = Random.Range(0, 4);

        if(randomPowerUp == 0 )
            Player.Instance.PowerUpController.StartPowerUp_Buldoze(_powerUpDuration);
        if (randomPowerUp == 1)
            Player.Instance.PowerUpController.StartPowerUp_Magnet(_powerUpDuration);
        if (randomPowerUp == 2)
            Player.Instance.PowerUpController.StartPowerUp_Fire(_powerUpUseCount, _powerUpDuration);
        if (randomPowerUp == 3)
            Player.Instance.PowerUpController.StartPowerUp_Jump(_powerUpUseCount, _powerUpDuration);
    }
}