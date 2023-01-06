using UnityEngine;

public class Tank_Jump : MonoBehaviour
{
    [Header("Jump Settings")]
    [SerializeField] private float _jumpShakeIntensity = 0.5f;

    private Animator _jumpAnimator = null;

    private bool _isGrounded = true;
    public bool IsGrounded => _isGrounded;

    private void Awake()
    {
        _jumpAnimator = GetComponent<Animator>();
    }

    public void Jump()
    {
        _jumpAnimator.Play("TankJump");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = true;

            Player.Instance.Tank.BuldozeStatus(false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Player.Instance.Tank.CinemachineController.ShakeCamera(_jumpShakeIntensity);

            _isGrounded = false;

            Player.Instance.Tank.BuldozeStatus(true);
        }
    }
}