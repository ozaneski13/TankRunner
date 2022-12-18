using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponentInChildren<MeshRenderer>().enabled = true;
        GetComponentInChildren<Collider>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
            return;

        gameObject.SetActive(false);
    }

    public void BlowUp()
    {
        GetComponentInChildren<MeshRenderer>().enabled = false;
        GetComponentInChildren<Collider>().enabled = false;

        //Turn off mesh renderer and collider. Open it before road generation
        //Start blow up animation
        //Increase points
    }
}