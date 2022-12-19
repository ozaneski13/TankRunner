using UnityEngine;

public abstract class Collectable : MonoBehaviour, ICollectable
{
    protected Player _player = null;

    private MeshRenderer _meshRenderer = null;
    private Collider _collider = null;

    private void Awake()
    {
        _meshRenderer = GetComponentInChildren<MeshRenderer>();
        _collider = GetComponentInChildren<Collider>();
    }

    private void Start()
    {
        _player = Player.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Tank")
            return;

        PlayerCollided();
    }

    public virtual void PlayerCollided()
    {
        _meshRenderer.enabled = false;
        _collider.enabled = false;

        CollectedVisuals();
    }

    public virtual void CollectedVisuals()
    {
        //Start collected animation
    }
}