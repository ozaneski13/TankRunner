using UnityEngine;

public abstract class Collectable : MonoBehaviour, ICollectable
{
    [SerializeField] private MeshRenderer _meshRenderer = null;
    [SerializeField] private Collider _collider = null;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Tank")
            return;

        Collected(other.gameObject);
    }

    public virtual void Collected(GameObject tank)
    {
        _meshRenderer.enabled = false;
        _collider.enabled = false;
    }
}