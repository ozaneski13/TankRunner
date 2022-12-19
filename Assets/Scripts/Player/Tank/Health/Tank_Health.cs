using UnityEngine;

public class Tank_Health : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private int _startingHealth = 3;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _startingHealth;
    }

    public void IncreaseHealth()
    {
        _currentHealth++;
    }

    public void DecreaseHealth()
    {
        if (_currentHealth == 0)
            ;//Game Over

        _currentHealth--;
    }
}