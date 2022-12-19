using UnityEngine;

public class Player : MonoBehaviour
{
    #region Singleton
    public static Player Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    #endregion

    [Header("Tank")]
    [SerializeField] private Tank _tank = null;
    public Tank Tank => _tank;

    [Header("Controllers")]
    [SerializeField] private PowerUpController _powerUpController = null;
    public PowerUpController PowerUpController => _powerUpController;
}