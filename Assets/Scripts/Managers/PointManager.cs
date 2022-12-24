using System.Collections;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    #region Singleton
    public static PointManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    #endregion

    [Header("Point Settings")]
    [SerializeField] private float _pointGainPerUnit = 5f;

    private Transform _tank = null;

    private Vector3 _startingPosition = Vector3.zero;
    private Vector3 _lastPosition = Vector3.zero;

    private float _totalPointGain = 0f;
    private int _totalGoldCount = 0;

    private void Start()
    {
        _tank = Player.Instance.Tank.transform;

        _startingPosition = _tank.position;
        _lastPosition = _startingPosition;

        StartCoroutine(PointRoutine());
    }

    private IEnumerator PointRoutine()
    {
        while (true)
        {
            _totalPointGain += (_tank.position - _lastPosition).z * _pointGainPerUnit;

            _lastPosition = _tank.position;

            yield return null;
        }
    }

    public void PointGained(float pointGain)
    {
        _totalGoldCount++;
        _totalPointGain += pointGain; 
    }
}