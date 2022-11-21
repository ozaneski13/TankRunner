using UnityEngine;

public class Car_Jump : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5f;
    private Rigidbody _rb = null;

    private bool _isGrounded = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                Jump();
        }
    }

    private void Jump()
    {
        if (!_isGrounded)
            return;

        Debug.Log(transform.up * _jumpForce);
        _rb.AddForce(transform.up * _jumpForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = false;
        }
    }
}