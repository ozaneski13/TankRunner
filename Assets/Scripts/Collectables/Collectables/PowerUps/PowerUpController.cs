using System.Collections;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    [Header("Tank")]
    [SerializeField] private Tank _tank = null;

    private IEnumerator _powerUpRoutine = null;

    private int _powerUpUseCount = 0;
    private bool _canUsePowerUp = false;

    private IEnumerator PowerUpRoutine(float duration)
    {
        _canUsePowerUp = true;

        yield return new WaitForSeconds(duration);

        _canUsePowerUp = false;
    }

    public void StartPowerUp_Fire(int fireCount, float powerUpDuration)
    {
        _powerUpUseCount = fireCount;

        _powerUpRoutine = PowerUpRoutine(powerUpDuration);

        StartCoroutine(_powerUpRoutine);
    }

    public void Fire()
    {
        if (!_canUsePowerUp || _powerUpUseCount == 0)
            return;

        _powerUpUseCount--;

        _tank.TankFire.Fire();

        if (_powerUpUseCount == 0)
            StopCoroutine(_powerUpRoutine);
    }

    public void StartPowerUp_Jump(int jumpCount, float powerUpDuration)
    {
        _powerUpUseCount = jumpCount;

        _powerUpRoutine = PowerUpRoutine(powerUpDuration);

        StartCoroutine(_powerUpRoutine);
    }

    public void Jump()
    {
        if (!_canUsePowerUp || _powerUpUseCount == 0)
            return;

        _powerUpUseCount--;

        _tank.TankJump.Jump();

        if (_powerUpUseCount == 0)
            StopCoroutine(_powerUpRoutine);
    }

    public void StartPowerUp_Buldoze(float powerUpDuration)
    {
        _powerUpRoutine = PowerUpRoutine(powerUpDuration);

        StartCoroutine(_powerUpRoutine);
    }

    public void Buldoze()
    {
        if (!_canUsePowerUp)
            return;
        
        //Buldoze
    }
}