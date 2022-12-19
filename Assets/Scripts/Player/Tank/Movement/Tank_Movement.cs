using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Tank_Movement : MonoBehaviour
{
    [Header("Lane Controller")]
    [SerializeField] private LaneController _laneController = null;

    [Header("Rotate Settings")]
    [SerializeField] private Transform[] _wheels = null;
    [SerializeField] private float _spinCoef = 3f;

    [Header("Speed Settings")]
    [SerializeField] private float _startSpeed = 40f;
    [SerializeField] private float _maxSpeed = 120f;
    [SerializeField] private float _speedUpCooldown = 5f;
    [SerializeField] private float _laneChangeDuration = 0.5f;
    [SerializeField] private int _speedUpCount = 4;

    private Rigidbody _rb = null;

    private Vector2 _startTouch;
    private Vector2 _swipeDelta;

    private float _currentSpeed = 0f;

    private List<int> _lanesXCoords = null;
    private int _currentLaneIndex;

    private bool _isDragging = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _currentSpeed = _startSpeed;

        GetLanes();

        StartCoroutine(SpeedRoutine());
    }

    private void Update()
    {
        CheckSwipe();

        RotateWheels();
    }

    private void FixedUpdate()
    {
        MoveForward();
    }

    private void GetLanes()
    {
        _lanesXCoords = _laneController.LanesXCoord;

        foreach (int lanePosition in _lanesXCoords)
            if (transform.position.x == lanePosition)
                _currentLaneIndex = _lanesXCoords.FindIndex(a => a == lanePosition);
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

    private void CheckSwipe()
    {
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                _isDragging = true;
                _startTouch = Input.touches[0].position;
            }

            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                _isDragging = false;

                Reset();
            }
        }

        _swipeDelta = Vector2.zero;

        if (_isDragging)
        {
            if (Input.touches.Length < 0)
                _swipeDelta = Input.touches[0].position - _startTouch;

            else if (Input.GetMouseButton(0))
                _swipeDelta = (Vector2)Input.mousePosition - _startTouch;
        }

        if (_swipeDelta.magnitude > 100)
        {
            float x = _swipeDelta.x;
            float y = _swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                {
                    if (_currentLaneIndex != 0)
                        _currentLaneIndex--;
                }

                else
                {
                    if (_currentLaneIndex != _lanesXCoords.Count - 1)
                        _currentLaneIndex++;
                }

                transform.DOMoveX(_lanesXCoords[_currentLaneIndex], _laneChangeDuration, false);
            }

            Reset();
        }
    }

    private void Reset()
    {
        _startTouch = _swipeDelta = Vector2.zero;
        _isDragging = false;
    }

    private void RotateWheels()
    {
        float _spinRotation = -_startSpeed * _spinCoef;

        foreach (Transform transform in _wheels)
        {
            transform.Rotate(_spinRotation * Time.deltaTime, 0, 0);
        }
    }

    private void MoveForward()
    {
        Vector3 velocity = (transform.forward) * _currentSpeed * Time.fixedDeltaTime;
        velocity.y = _rb.velocity.y;
        _rb.velocity = velocity;
    }

    public void Crashed()
    {
        _currentSpeed = _startSpeed;
    }
}