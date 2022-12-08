using System.Collections.Generic;
using UnityEngine;

public class Tank_Movement : MonoBehaviour
{
    [Header("Lane Controller")]
    [SerializeField] private LaneController _laneController = null;

    [Header("Rotate Settings")]
    [SerializeField] private Transform[] _wheels = null;
    [SerializeField] private float _spinCoef = 3f;

    [Header("Speed Settings")]
    [SerializeField] private float _speed = 40f;

    private Rigidbody _rb = null;

    private Vector2 _startTouch;
    private Vector2 _swipeDelta;

    private List<int> _lanesXCoords = null;
    private int _currentLaneIndex;

    private bool _isDragging = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        GetLanes();
    }

    private void Update()
    {
        CheckSwipe();

        RotateWheels();
    }

    private void FixedUpdate()
    {
        Vector3 velocity = (transform.forward) * _speed * Time.fixedDeltaTime;
        velocity.y = _rb.velocity.y;
        _rb.velocity = velocity;
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
                    {
                        _currentLaneIndex--;

                        transform.position = new Vector3(_lanesXCoords[_currentLaneIndex], transform.position.y, transform.position.z);
                    }
                }

                else
                {
                    if (_currentLaneIndex != _lanesXCoords.Count - 1)
                    {
                        _currentLaneIndex++;

                        transform.position = new Vector3(_lanesXCoords[_currentLaneIndex], transform.position.y, transform.position.z);
                    }
                }
            }

            Reset();
        }
    }

    private void GetLanes()
    {
        _lanesXCoords = _laneController.LanesXCoord;

        foreach (int lanePosition in _lanesXCoords)
            if (transform.position.x == lanePosition)
                _currentLaneIndex = _lanesXCoords.FindIndex(a => a == lanePosition);
    }

    private void Reset()
    {
        _startTouch = _swipeDelta = Vector2.zero;
        _isDragging = false;
    }

    private void RotateWheels()
    {
        float _spinRotation = -_speed * _spinCoef;

        foreach(Transform transform in _wheels)
        {
            transform.Rotate(_spinRotation * Time.deltaTime, 0, 0);
        }
    }
}