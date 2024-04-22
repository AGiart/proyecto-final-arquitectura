using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarGolem : MonoBehaviour
{
    private Slider slider;


    public void ChangeMaxHealth(float MaxHealth)
    {
        slider.maxValue = MaxHealth;
    }

    public void ChangeCurrentHealth(float AmountHealth)
    {
        slider.value = AmountHealth;
    }

    public void StartHealthBar(float AmountHealth)
    {
        slider = GetComponent<Slider>();
        ChangeCurrentHealth(AmountHealth);
        ChangeCurrentHealth(AmountHealth);
    }
}
