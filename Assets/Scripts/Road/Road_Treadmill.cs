using UnityEngine;

public class Road_Treadmill : MonoBehaviour
{
    [Header("Treadmill Settings")]
    [SerializeField] private float _treadmillSpeed = 40f;

    private void Update()
    {
        MoveTreadmill();
    }

    private void MoveTreadmill()
    {
        transform.Translate(Vector3.back * Time.deltaTime * _treadmillSpeed);
    }
}
