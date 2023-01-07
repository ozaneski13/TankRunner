using UnityEngine;

public class StartManager : MonoBehaviour
{
    private void Start()
    {
        foreach(var tankModel in Player.Instance.TankPrefabs)
        {
            tankModel.gameObject.SetActive(false);
        }

        Player.Instance.Tank.TankHealth.IncreaseHealth(1000);
        Player.Instance.TankPrefabs[(int)(Player.Instance.CurrentTank)].gameObject.SetActive(true);
        Player.Instance.Tank.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotation;
        Player.Instance.Tank.transform.position = new Vector3(0, 1f, 15f);
        Player.Instance.Tank.GetModel();
        Player.Instance.Tank.GetMaterials();
    }
}