using UnityEngine;

public class Usable_Coin : Usables
{
    [Header("Coin Settings")]
    [SerializeField] private float _point = 100f;

    public override void PlayerCollided()
    {
        base.PlayerCollided();

        PointManager.Instance.PointGained(_point);
    }
}