using System;
using UnityEngine;

public class Tank_Health : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private int _startingHealth = 100;
    public int StartingHealth => _startingHealth;

    private int _currentHealth;

    public Action HealthIncreased;
    public Action HealthDecreased;

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

        HealthIncreased?.Invoke();
    }

    public void DecreaseHealth(int damage)
    {
        if (_currentHealth - damage <= 0)
        {
            ;//Game Over
            return;
        }

        _currentHealth -= damage;
        HealthDecreased?.Invoke();
}

    public int GetHealth()
    {
        return _currentHealth;
    }
}