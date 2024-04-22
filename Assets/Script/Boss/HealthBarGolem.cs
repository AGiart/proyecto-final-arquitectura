using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarGolem : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

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
        ChangeCurrentHealth(AmountHealth);
        ChangeCurrentHealth(AmountHealth);
    }
}
