using UnityEngine;

public class Tank_Health : MonoBehaviour
{
    private int _startingHealth; //Connect to save system
    private int _currentHealth;

    public void IncreaseHealth()
    {
        _currentHealth++;
    }

    public void DecreaseHealth()
    {
        _currentHealth--;
    }
}