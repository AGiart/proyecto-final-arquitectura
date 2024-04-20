using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField]
    public int maxHealth; // Vida m�xima del enemigo
    private int currentHealth; // Vida actual del enemigo

    public Animator animator;

    void Start()
    {
        currentHealth = maxHealth; // Al iniciar, la vida actual es igual a la vida m�xima
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
        animator.SetTrigger("Dead");
        Destroy(gameObject,2F); // Destruye al�enemigo
����}
}