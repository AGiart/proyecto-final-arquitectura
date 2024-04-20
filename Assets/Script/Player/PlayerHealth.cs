using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public HealthBarController healthBarController;

    public void TakeDamage(float damage)
    {
        healthBarController.UpdateHealth(-damage);
    }
}