using UnityEngine;

public class Tank_Fire : MonoBehaviour
{
    [Header("Fire Collider")]
    [SerializeField] private Transform _fireBox = null;

    [SerializeField] private LayerMask _hitLayers;

    public void Fire()
    {
        Collider[] hits = Physics.OverlapBox(_fireBox.position, _fireBox.localScale/2, Quaternion.identity ,_hitLayers);

        foreach (Collider hit in hits)
            hit.GetComponent<Obstacle>().BlowUp();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawWireCube(_fireBox.position, _fireBox.localScale);
    }
}