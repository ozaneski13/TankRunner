using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    #region Singleton
    public static RoadManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    #endregion

    [Header("Road Environment Settings")]
    [SerializeField] private List<Transform> _roadEnvironmentPrefabs = new List<Transform>();
    [SerializeField] private float _environmentOffset = 5f;

    [Header("Pooling Settings")]
    [SerializeField] private Transform _roadEnvironmentParent = null;
    [SerializeField] private Transform _roadEnvironmentPoolParent = null;
    [SerializeField] private int _poolSize = 20;

    private List<Transform> _roadEnvironmentPool = new List<Transform>();

    [Header("Phase Starting Point")]
    [SerializeField] private Transform _lastPreCreatedRoad = null;

    [Header("Penultiamte Point")]
    [SerializeField] private Transform _penultimateRoad = null;

    private List<Transform> _activatedRoadEnvironments = new List<Transform>();

    private Transform _roadToDelete = null;
    private Transform _lastRoad = null;

    private Vector3 _phaseStartingPosition = Vector3.zero;
    private Vector3 _currentPosition = Vector3.zero;

    private void Start()
    {
        CreatePool();

        _phaseStartingPosition = _lastPreCreatedRoad.position;
        _currentPosition = _phaseStartingPosition;

        _roadToDelete = _penultimateRoad;
        _lastRoad = _lastPreCreatedRoad;
    }

    private void CreatePool()
    {
        foreach(Transform roadEnvironment in _roadEnvironmentPrefabs) 
        {
            for (int i = 0; i < _poolSize; i++)
            {
                Transform roadEnviromentPoolMember = Instantiate(roadEnvironment, Vector3.zero, Quaternion.identity, _roadEnvironmentPoolParent);
                roadEnviromentPoolMember.gameObject.SetActive(false);

                _roadEnvironmentPool.Add(roadEnviromentPoolMember);
            }
        }

        Shuffle();
    }

    private void Shuffle()
    {
        var random = new System.Random();

        _roadEnvironmentPool = _roadEnvironmentPool.OrderBy(_ => random.Next()).ToList();
    }

    private void CreateNextPhase()
    {
        Vector3 newPosition = _currentPosition + new Vector3(0, 0, _environmentOffset);

        foreach (Transform roadEnvironment in _roadEnvironmentPool)
        {
            if (_lastRoad.GetComponent<Road>().RoadEnvironmentType != roadEnvironment.GetComponent<Road>().RoadEnvironmentType)
            {
                GameObject nextRoad = _roadEnvironmentPool[0].gameObject;
                nextRoad.transform.parent = _roadEnvironmentParent;
                nextRoad.transform.position = newPosition;
                nextRoad.SetActive(true);

                _roadEnvironmentPool.Remove(_roadEnvironmentPool[0]);
                _activatedRoadEnvironments.Add(nextRoad.transform);

                _currentPosition = newPosition;
                _lastRoad = nextRoad.transform;

                break;
            }
        }
    }

    public void DeletePassedPhases(Transform passedRoad)
    {
        _roadToDelete.gameObject.SetActive(false);
        _roadToDelete.parent = _roadEnvironmentPoolParent;

        _roadEnvironmentPool.Add(_roadToDelete);
        _activatedRoadEnvironments.Remove(_roadToDelete);

        _roadToDelete = passedRoad;

        CreateNextPhase();
    }
}