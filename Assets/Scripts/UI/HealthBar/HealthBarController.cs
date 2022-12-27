using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField]
    private Slider HealthBarSlider;

    private void FixedUpdate()
    {
        if(Player.Instance.Tank.TankHealth.GetHealth() != HealthBarSlider.value)
        {
            HealthBarSlider.value = Player.Instance.Tank.TankHealth.GetHealth();
        }
    }

}
