using UnityEngine;

public class Tank_Jump : MonoBehaviour
{
    [Header("Jump Settings")]
    [SerializeField] private float _jumpForce = 200f;

    private Rigidbody _rb = null;

    private bool _isGrounded = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        if (!_isGrounded)
            return;

        _rb.AddForce(transform.up * _jumpForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = false;
        }
    }
}