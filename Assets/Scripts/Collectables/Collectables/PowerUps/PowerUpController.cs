using System.Collections;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    private Player _player = null;

    private Tank _tank = null;

    private IEnumerator _powerUpRoutine = null;

    private int _powerUpUseCount = 0;
    private bool _canUsePowerUp = true;

    private void Start()
    {
        _player = Player.Instance;

        _tank = _player.Tank;
    }

    private IEnumerator PowerUpRoutine(float duration, EStatus newStatus)
    {
        _tank.SetStatus(newStatus);
        _canUsePowerUp = false;

        yield return new WaitForSeconds(duration);

        _canUsePowerUp = true;
        _tank.SetStatus(EStatus.Normal);

        if (newStatus == EStatus.Buldozer)
            _tank.BuldozeStatus(false);
    }

    public void StartPowerUp_Fire(int fireCount, float powerUpDuration)
    {
        _powerUpUseCount = fireCount;

        _powerUpRoutine = PowerUpRoutine(powerUpDuration, EStatus.Fire);

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

        _powerUpRoutine = PowerUpRoutine(powerUpDuration, EStatus.Jump);

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
        _powerUpRoutine = PowerUpRoutine(powerUpDuration, EStatus.Buldozer);

        StartCoroutine(_powerUpRoutine);
    }

    public void Buldoze()
    {
        if (!_canUsePowerUp)
            return;

        _tank.BuldozeStatus(true);
    }
}