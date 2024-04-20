using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public int maxHealth = 20; // Vida máxima del enemigo
    private int currentHealth; // Vida actual del enemigo

    public Animator animator;

    void Start()
    {
        currentHealth = maxHealth; // Al iniciar, la vida actual es igual a la vida máxima
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reducir la vida del enemigo

        if (currentHealth <= 0)
        {
            Die(); // llama al metodo de muerte
        }
    }

    void Die()
    {
        animator.SetTrigger("dead");
        Destroy(gameObject,2F); // Destruye al enemigo
    }
}