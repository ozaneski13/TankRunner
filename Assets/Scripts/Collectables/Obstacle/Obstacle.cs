using UnityEngine;

public class Obstacle : Collectable
{
    [Header("Obstacle Settings")]
    [SerializeField] private int _damage = 1;
    public int Damage => _damage;
    [SerializeField] private float _blowUpPoint = 100f;

    private PointManager _pointManager = null;

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
        //Start blow up animation

        if (_player.Tank.IsImmune)
            return;

        _pointManager.PointGained(_blowUpPoint);
    }
}