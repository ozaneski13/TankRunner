using UnityEngine;

public class Obstacle : Collectable
{
    [Header("Point Manager")]
    [SerializeField] private PointManager _pointManager = null;

    [Header("Obstacle Settings")]
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

    public override void PlayerCollided()
    {
        base.PlayerCollided();
    }

    public override void CollectedVisuals()
    {
        _pointManager.PointGained(_blowUpPoint);

        //Start blow up animation
    }
}