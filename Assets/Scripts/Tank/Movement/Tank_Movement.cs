using UnityEngine;

public class Tank_Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private Rigidbody _rb = null;

    private Vector2 _startTouch;
    private Vector2 _swipeDelta;

    private bool _isDragging = false;
    private bool _swipeLeft;
    private bool _swipeRight;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
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
                    Debug.Log("Swipe Left"); //_swipeLeft = true;

                else
                    Debug.Log("Swipe Right"); //_swipeRight = true;
            }

            Reset();
        }
    }

    private void FixedUpdate()
    {
        Vector3 velocity = (transform.forward) * _speed * Time.fixedDeltaTime;
        velocity.y = _rb.velocity.y;
        _rb.velocity = velocity;
    }

    private void Reset()
    {
        _startTouch = _swipeDelta = Vector2.zero;
        _isDragging = false;
    }
}