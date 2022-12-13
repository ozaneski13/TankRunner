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

    public void Fire()
    {

    }

    public void Jump()
    {

    }

    public void Buldozer()
    {

    }
}