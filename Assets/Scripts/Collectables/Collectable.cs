using UnityEngine;

public abstract class Collectable : MonoBehaviour, ICollectable
{
    private MeshRenderer[] _meshRenderers = null;
    private Collider[] _colliders = null;

    private Transform _startTransform = null;

    public virtual void Awake()
    {
        _meshRenderers = GetComponentsInChildren<MeshRenderer>();
        _colliders = GetComponentsInChildren<Collider>();

        _startTransform = transform;
    }

    private void OnEnable()
    {
        transform.position = _startTransform.position;
        transform.rotation = _startTransform.rotation;

        foreach (MeshRenderer meshRenderer in _meshRenderers)
            meshRenderer.enabled = true;

        foreach (Collider collider in _colliders)
            collider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Tank")
            return;

        PlayerCollided();
    }

    public virtual void PlayerCollided()
    {
        foreach(MeshRenderer meshRenderer in _meshRenderers)
            meshRenderer.enabled = false;

        foreach (Collider collider in _colliders)
            collider.enabled = false;

        CollectedVisuals();
    }

    public virtual void CollectedVisuals()
    {
        //Start collected animation
    }
}