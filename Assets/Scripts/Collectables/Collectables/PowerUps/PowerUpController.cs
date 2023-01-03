using System.Collections;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    [Header("Reload Duration of Gun")]
    [SerializeField] private float _reloadDutaion = 0.5f;

    private Tank _tank = null;

    private IEnumerator _powerUpRoutine = null;

    private int _powerUpUseCount = 0;

    private bool _canShoot = true;
    private bool _canUsePowerUp = true;

    private void Start()
    {
        _tank = Player.Instance.Tank;
    }

    private IEnumerator PowerUpRoutine(float duration, EStatus newStatus)
    {
        _tank.SetStatus(newStatus);

        if(newStatus == EStatus.Buldozer)
            _tank.BuldozeStatus(true);
        else if (newStatus == EStatus.Magnet)
            _tank.TankMagnet.ToggleMagnet(true);

        yield return new WaitForSeconds(duration);

        _canUsePowerUp = true;
        _tank.SetStatus(EStatus.Normal);

        if (newStatus == EStatus.Buldozer)
            _tank.BuldozeStatus(false);

        else if (newStatus == EStatus.Magnet)
            _tank.TankMagnet.ToggleMagnet(false);

        _tank.ImmuneStatus(false);
    }

    public void StartPowerUp_Fire(int fireCount, float powerUpDuration)
    {
        if (!_canUsePowerUp)
            return;

        _powerUpUseCount = fireCount;

        _powerUpRoutine = PowerUpRoutine(powerUpDuration, EStatus.Fire);

        StartCoroutine(_powerUpRoutine);
    }

    public void Fire()
    {
        if (_powerUpUseCount != 0 && _canShoot)
        {
            _powerUpUseCount--;

            _tank.TankFire.Fire();

            StartCoroutine(ReloadRoutine());
        }

        else if (_powerUpUseCount == 0)
        {
            StopCoroutine(_powerUpRoutine);

            _canUsePowerUp = true;
            _tank.SetStatus(EStatus.Normal);
        }
    }

    private IEnumerator ReloadRoutine()
    {
        _canShoot = false;

        yield return new WaitForSeconds(_reloadDutaion);

        _canShoot = true;
    }

    public void StartPowerUp_Jump(int jumpCount, float powerUpDuration)
    {
        if (!_canUsePowerUp)
            return;

        _canUsePowerUp = false;

        _powerUpUseCount = jumpCount;

        _powerUpRoutine = PowerUpRoutine(powerUpDuration, EStatus.Jump);

        StartCoroutine(_powerUpRoutine);
    }

    public void Jump()
    {
        if (_tank.TankJump.IsGrounded && _tank.GetStatus() == EStatus.Jump && _powerUpUseCount != 0)
        {
            _tank.TankJump.Jump();

            _powerUpUseCount--;
        }

        else if (_powerUpUseCount == 0)
        {
            StopCoroutine(_powerUpRoutine);

            _canUsePowerUp = true;
            _tank.SetStatus(EStatus.Normal);
        }
    }

    public void StartPowerUp_Buldoze(float powerUpDuration)
    {
        if (!_canUsePowerUp)
            return;

        _powerUpRoutine = PowerUpRoutine(powerUpDuration, EStatus.Buldozer);

        StartCoroutine(_powerUpRoutine);
    }

    public void StartPowerUp_Magnet(float powerUpDuration)
    {
        if (!_canUsePowerUp)
            return;

        _powerUpRoutine = PowerUpRoutine(powerUpDuration, EStatus.Magnet);

        StartCoroutine(_powerUpRoutine);
    }
}