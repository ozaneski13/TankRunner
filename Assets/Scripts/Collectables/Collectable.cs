using UnityEngine;

public abstract class Collectable : MonoBehaviour, ICollectable
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Tank")
            return;

        Collected(other.gameObject);
    }

    public virtual void Collected(GameObject tank)
    {
        gameObject.SetActive(false);
    }
}