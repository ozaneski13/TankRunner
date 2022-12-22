using UnityEngine;

public class Obstacle : Collectable
{
    [Header("Point Manager")]
    [SerializeField] private PointManager _pointManager = null;

    [Header("Obstacle Settings")]
    [SerializeField] private int _damage = 1;
    public int Damage => _damage;
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
        if (other.gameObject.tag != "Tank")
            return;

        GetComponentInChildren<MeshRenderer>().enabled = false;
        GetComponentInChildren<Collider>().enabled = false;
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