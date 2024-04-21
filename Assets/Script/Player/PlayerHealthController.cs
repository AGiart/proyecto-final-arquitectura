using UnityEngine;
using System.Collections;

public class PlayerHealthController : MonoBehaviour
{
    public int maxHealth = 100; // Vida máxima del jugador
    public int currentHealth; // Vida actual del jugador

    public PlayerController2D playerController;

    public Animator animator;

    public GameOver gameOver;

    void Start()
    {
        currentHealth = maxHealth; // Al iniciar, la vida actual es igual a la vida máxima
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reducir la vida del jugador
        //Debug.Log("Player took " + damage + " damage. Current health: " + currentHealth); // Mensaje de depuración
        if (currentHealth <= 0)
        {
            Die(); // Llama al método Die para la animación de muerte
        }

    }

    public void Die()
    {
        animator.SetTrigger("dead");
        StartCoroutine(DisableMovement()); // Deshabilita el movimiento del jugador
    }

    private IEnumerator DisableMovement()
    {
        // Desactiva el script PlayerController2D
        playerController.enabled = false;

        yield return new WaitForSeconds(1.5f); // Espera antes de desactivar el objeto
        gameObject.SetActive(false);

        gameOver.gameObject.SetActive(true);
    }
}