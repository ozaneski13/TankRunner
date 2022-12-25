using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tank_Movement : MonoBehaviour
{
    [Header("Lane Change Settings")]
    [SerializeField] private LaneController _laneController = null;
    [SerializeField] private float _laneChangeDuration = 0.5f;

    [Header("Rotate Settings")]
    [SerializeField] private float _spinCoef = 5f;

    private List<Transform> _wheels = null;

    private Vector2 _startTouch;
    private Vector2 _swipeDelta;

    private List<int> _lanesXCoords = null;
    private int _currentLaneIndex;

    private bool _isDragging = false;
    private bool _isModelReady = false;

    private void Start()
    {
        GetLanes();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_currentLaneIndex != 0)
                _currentLaneIndex--;
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
            if (_currentLaneIndex != _lanesXCoords.Count - 1)
                _currentLaneIndex++;

        transform.DOMoveX(_lanesXCoords[_currentLaneIndex], _laneChangeDuration, false);

        CheckSwipe();

        if (_isModelReady)
            RotateWheels();
    }

    private void GetLanes()
    {
        _lanesXCoords = _laneController.LanesXCoord;

        foreach (int lanePosition in _lanesXCoords)
            if (transform.position.x == lanePosition)
                _currentLaneIndex = _lanesXCoords.FindIndex(a => a == lanePosition);
    }

    public void GetWheels(Tank_Model tankModel)
    {
        _wheels = tankModel.Wheels;

        _isModelReady = true;
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
        foreach (Transform transform in _wheels)
            transform.Rotate(-_spinCoef * RoadManager.Instance.RoadTreadmill.CurrentSpeed * Time.deltaTime, 0, 0);
    }
}