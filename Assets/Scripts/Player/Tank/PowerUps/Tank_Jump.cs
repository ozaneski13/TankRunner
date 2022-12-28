using UnityEngine;

public class Tank_Jump : MonoBehaviour
{
    [Header("Jump Settings")]
    [SerializeField] private float _jumpForce = 200f;
    [SerializeField] private float _jumpShakeIntensity = 0.5f;

    private Player _player = null;

    private Rigidbody _rb = null;

    private bool _isGrounded = true;
    public bool IsGrounded => _isGrounded;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        //_player = Player.Instance;
    }

    public void Jump()
    {
        _rb.AddForce(transform.up * _jumpForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = true;

            //_player.Tank.BuldozeStatus(false);
            Player.Instance.Tank.BuldozeStatus(false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //_player.Tank.CinemachineController.ShakeCamera(_jumpShakeIntensity);
            Player.Instance.Tank.CinemachineController.ShakeCamera(_jumpShakeIntensity);

            _isGrounded = false;

            //_player.Tank.BuldozeStatus(true);
            Player.Instance.Tank.BuldozeStatus(true);
        }
    }
}