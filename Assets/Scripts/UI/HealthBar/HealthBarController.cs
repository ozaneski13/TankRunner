using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private Slider _healthBarSlider = null;

    private void Start()
    {
        _healthBarSlider = GetComponent<Slider>();
        _healthBarSlider.maxValue = Player.Instance.Tank.TankHealth.StartingHealth;

        RegisterToEvents();
    }

    private void OnDestroy()
    {
        UnregisterFromEvents();
    }

    private void RegisterToEvents()
    {
        Player.Instance.Tank.TankHealth.HealthIncreased += UpdateHealthBar;
        Player.Instance.Tank.TankHealth.HealthDecreased += UpdateHealthBar;
    }

    private void UnregisterFromEvents()
    {
        Player.Instance.Tank.TankHealth.HealthIncreased -= UpdateHealthBar;
        Player.Instance.Tank.TankHealth.HealthDecreased -= UpdateHealthBar;
    }

    private void UpdateHealthBar()
    {
        _healthBarSlider.value = Player.Instance.Tank.TankHealth.GetHealth();
    }
}