using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private ERoad _roadEnvironmentType = ERoad.Default;

    private RoadManager _roadManager = null;

    private bool _isRoadPassed = false;

    private void Start()
    {
        _roadManager = RoadManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Tank") && !_isRoadPassed)
        {
            _isRoadPassed = true;
            _roadManager.DeletePassedPhases(transform);
        }
    }
}