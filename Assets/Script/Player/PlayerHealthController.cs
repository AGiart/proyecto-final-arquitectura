using UnityEngine;
using System.Collections;

public class PlayerHealthController : MonoBehaviour
{
    public int maxHealth = 100; // Vida m�xima del jugador
    public int currentHealth; // Vida actual del jugador

    public PlayerController2D playerController;

    public Animator animator;

    public GameOver gameOver;

    void Start()
    {
        currentHealth = maxHealth; // Al iniciar, la vida actual es igual a la vida m�xima
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reducir la vida del jugador
        //Debug.Log("Player took " + damage + " damage. Current health: " + currentHealth); // Mensaje de depuraci�n
        if (currentHealth <= 0)
        {
            Die(); // Llama al m�todo Die para la animaci�n de muerte
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