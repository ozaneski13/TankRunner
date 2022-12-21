using System.Collections;
using UnityEngine;

public class Road_Treadmill : MonoBehaviour
{
    [Header("Treadmill Settings")]
    [SerializeField] private float _startSpeed = 5f;
    [SerializeField] private float _maxSpeed = 10f;
    [SerializeField] private float _speedUpCooldown = 5f;
    [SerializeField] private int _speedUpCount = 4;

    private float _currentSpeed = 0f;
    public float CurrentSpeed => _currentSpeed;

    private void Start()
    {
        _currentSpeed = _startSpeed;

        StartCoroutine(SpeedRoutine());
    }

    private void Update()
    {
        MoveTreadmill();
    }

    private void MoveTreadmill()
    {
        transform.Translate(Vector3.back * Time.deltaTime * _currentSpeed);
    }

    private IEnumerator SpeedRoutine()
    {
        while (true)
        {
            if (_currentSpeed != _maxSpeed)
            {
                yield return new WaitForSeconds(_speedUpCooldown);

                _currentSpeed += (_maxSpeed - _startSpeed) / _speedUpCount;
            }

            else yield return null;
        }
    }

    public void TankCrashed()
    {
        _currentSpeed = _startSpeed;
    }
}