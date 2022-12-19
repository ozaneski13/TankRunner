using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Header("Point Manager")]
    [SerializeField] private PointManager _pointManager = null;

    [Header("Obstacle Settings")]
    [SerializeField] private int _pointForDestroy = 10;
    [SerializeField] private float _blowUpPoint = 100f;

    private void Start()
    {
        _pointManager = PointManager.Instance;
    }

    private void OnEnable()
    {
        GetComponentInChildren<MeshRenderer>().enabled = true;
        GetComponentInChildren<Collider>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
            return;

        gameObject.SetActive(false);
    }

    public void BlowUp()
    {
        GetComponentInChildren<MeshRenderer>().enabled = false;
        GetComponentInChildren<Collider>().enabled = false;

        _pointManager.PointGained(_blowUpPoint);

        //Start blow up animation
    }
}