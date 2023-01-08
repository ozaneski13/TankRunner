using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSoundController : MonoBehaviour
{
    #region Singleton
    public static CoinSoundController Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    #endregion

    [SerializeField] private AudioSource _coinSound = null;
    [SerializeField] private float _pitchIncrease = 0.5f;
    [SerializeField] private int _durationBeforeNormalPitch = 1;

    private IEnumerator _coinSoundRoutine;

    private float _startPitch;

    private bool _routineStarted = false;

    private void Start()
    {
        _startPitch = _coinSound.pitch;
    }

    public void CoinCollected()
    {
        if (_coinSound.pitch < 13)
            _coinSound.pitch += _pitchIncrease;

        _coinSound.Play();

        if (_routineStarted)
            StopCoroutine(_coinSoundRoutine);

        _coinSoundRoutine = CoinSoundRoutine();
        StartCoroutine(_coinSoundRoutine);
    }

    private IEnumerator CoinSoundRoutine()
    {
        _routineStarted = true;

        yield return new WaitForSeconds(_durationBeforeNormalPitch);

        _coinSound.pitch = _startPitch;

        _routineStarted = false;
    }
}