using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [Header("Spawn Options")]
    [SerializeField] private List<Transform> _carPrefabs = new List<Transform>();
    [SerializeField] private Transform _carPoolParent = null;
    [SerializeField] private float _maxDurationBeforeSpawn = 3f;
    [SerializeField] private float _minDurationBeforeSpawn = 6f;
    [SerializeField] private int _maxSpawnCount = 2;

    private List<Transform> _carPool = new List<Transform>();

    private void Awake()
    {
        FillCarPool();
    }

    private void OnEnable()
    {
        StartCoroutine(SpawnRoutine());
    }

    private void OnDisable()
    {
        CollectCars();
    }

    private void FillCarPool()
    {
        var random = new System.Random();

        _carPrefabs = _carPrefabs.OrderBy(_ => random.Next()).ToList();

        for (int i = 0; i < _maxSpawnCount; i++)
        {
            Transform tempTransform = Instantiate(_carPrefabs[i], transform.position, _carPrefabs[i].transform.rotation, _carPoolParent);
            tempTransform.gameObject.SetActive(false);

            _carPool.Add(tempTransform);
        }
    }

    private IEnumerator SpawnRoutine()
    {
        int random = Random.Range(0, _carPool.Count);

        yield return new WaitForSeconds(Random.Range(_minDurationBeforeSpawn, _maxDurationBeforeSpawn));

        _carPool[random].gameObject.SetActive(true);
    }

    private void CollectCars()
    {
        foreach(Transform car in _carPool)
        {
            car.position = transform.position;
            car.gameObject.SetActive(false);
        }
    }
}