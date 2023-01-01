using UnityEngine;

public abstract class Collectable : MonoBehaviour, ICollectable
{
    [SerializeField] private MeshRenderer _meshRenderer = null;
    [SerializeField] private BoxCollider _collider = null;

    protected Player _player = null;

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