using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Car_Movement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _speed = 10f;

    [Header("Rotate Settings")]
    [SerializeField] private float _spinCoef = 5f;

    [Header("Test")]
    [SerializeField] private bool _canDestroyCoins = false;

    private List<Transform> _wheels = null;

    private Rigidbody _rigidbody = null;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _wheels = GetComponent<Obstacle_Car_Model>().Wheels;
    }

    private void Update()
    {
        RotateWheels();
    }

    private void FixedUpdate()
    {
        MoveForward();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
            gameObject.SetActive(false);

        if (other.gameObject.tag == "Collectable" && _canDestroyCoins)
            other.gameObject.SetActive(false);
    }

    private void RotateWheels()
    {
        foreach (Transform transform in _wheels)
            transform.Rotate(_spinCoef * RoadManager.Instance.RoadTreadmill.CurrentSpeed * Time.deltaTime, 0, 0);
    }

    private void MoveForward()
    {
        Vector3 velocity = (transform.forward) * _speed * Time.fixedDeltaTime;
        velocity.y = _rigidbody.velocity.y;
        _rigidbody.velocity = velocity;
    }
}