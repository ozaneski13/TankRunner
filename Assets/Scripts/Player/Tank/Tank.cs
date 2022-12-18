using UnityEngine;

public class Tank : MonoBehaviour
{
    [Header("Tank Scripts")]
    [SerializeField] private Tank_Jump _tankJump = null;
    public Tank_Jump TankJump => _tankJump;

    [SerializeField] private Tank_Fire _tankFire = null;
    public Tank_Fire TankFire=> _tankFire;

    [SerializeField] private Tank_Health _tankHealth = null;
    public Tank_Health TankHealth => _tankHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Collectable")
            return;
        
        Collectable collectable = other.gameObject.GetComponent<Collectable>();
    }
}