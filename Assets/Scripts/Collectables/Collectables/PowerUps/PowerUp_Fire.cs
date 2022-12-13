using System.Collections;
using UnityEngine;

public class PowerUp_Fire : PowerUps
{
    [SerializeField] private int _fireCount = 3;
    [SerializeField] private float _doubleTapThreshold = 0.3f;

    private IEnumerator _fireCountdownRoutine = null;

    private bool _canFire = false;

    public override void Collected(GameObject tank)
    {
        base.Collected(tank);

        StartCountdown();
    }

    private void StartCountdown()
    {
        _fireCountdownRoutine = FireCountdownRoutine();
        StartCoroutine(_fireCountdownRoutine);
    }

    private IEnumerator FireCountdownRoutine()
    {
        _canFire = true;

        yield return new WaitForSeconds(_powerUpDuration);

        _canFire = false;
    }

    private void Fire()
    {
        if (!_canFire || _fireCount == 0)
            return;

        _fireCount--;
        //Do some firing
    }
}