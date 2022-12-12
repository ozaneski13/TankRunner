using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Collectable")
            return;
        
        Collectable collectable = other.gameObject.GetComponent<Collectable>();
    }
}