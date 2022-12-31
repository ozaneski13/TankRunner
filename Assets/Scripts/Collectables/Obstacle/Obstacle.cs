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
        ToggleObstacles(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Tank")
            return;

        ToggleObstacles(false);
    }

    private void ToggleObstacles(bool toggle)
    {
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();
        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach(MeshRenderer meshRenderer in meshRenderers)
            meshRenderer.enabled = toggle;

        foreach (Collider collider in colliders)
            collider.enabled = toggle;
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