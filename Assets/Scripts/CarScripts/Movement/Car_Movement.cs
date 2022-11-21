using UnityEngine;

public class Car_Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private Rigidbody _rb = null;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 velocity = (transform.forward) * _speed * Time.fixedDeltaTime;
        velocity.y = _rb.velocity.y;
        _rb.velocity = velocity;
    }
}