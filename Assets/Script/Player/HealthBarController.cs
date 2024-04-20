using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField]
    private Image healthBar;

    [SerializeField]
    private Gradient healthGradient;

    [SerializeField]
    private float maxHealth = 100.0f;

    private float currentHealth;

    [SerializeField]
    private PlayerHealthController _currentHealth;

    private void Update()
    {
        currentHealth = _currentHealth.currentHealth;
        UpdateHealthBar();

    }

    private void Awake()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void UpdateHealth(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0.0f, maxHealth);
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float fillAmount = currentHealth / maxHealth;
        Color fillColor = healthGradient.Evaluate(fillAmount);

        healthBar.fillAmount = fillAmount;
        healthBar.color = fillColor;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}