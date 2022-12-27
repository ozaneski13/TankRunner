using UnityEngine;

public class Tank_Health : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private int _startingHealth = 100;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _startingHealth;
    }

    public void IncreaseHealth(int heal)
    {
        if (_currentHealth + heal <= _startingHealth)
            _currentHealth += heal;
        else
            _currentHealth = 100;
    }

    public void DecreaseHealth(int damage)
    {
        if (_currentHealth - damage <= 0)
            ;//Game Over

        _currentHealth -= damage;
    }

    public int GetHealth()
    {
        return _currentHealth;
    }
}