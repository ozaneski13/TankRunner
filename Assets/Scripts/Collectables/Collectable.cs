using UnityEngine;

public abstract class Collectable : MonoBehaviour, ICollectable
{
    protected Player _player = null;

    private MeshRenderer _meshRenderer = null;
    private Collider _collider = null;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
    }

    private void Start()
    {
        _player = Player.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Tank")
            return;

        CollectableCollected();
    }

    public virtual void CollectableCollected()
    {
        _meshRenderer.enabled = false;
        _collider.enabled = false;
    }
}