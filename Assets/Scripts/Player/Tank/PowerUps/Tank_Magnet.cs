using UnityEngine;

public class Tank_Magnet : MonoBehaviour
{
    public void ToggleMagnet(bool toggle)
    {
        GetComponent<BoxCollider>().enabled = toggle;
    }
}