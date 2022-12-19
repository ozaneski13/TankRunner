using UnityEngine;

public class Tank_Jump : MonoBehaviour
{
    [Header("Jump Settings")]
    [SerializeField] private float _jumpForce = 200f;

    private Player _player = null;

    private Rigidbody _rb = null;

    private bool _isGrounded = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _player = Player.Instance;
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

            _player.Tank.BuldozeStatus(false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = false;

            _player.Tank.BuldozeStatus(true);
        }
    }
}