using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Animator animator;

    public PlayerController2D playerController;

    public PlayerHealthController playerHealth;

    public GameOver timeOut;


    [SerializeField]
    Image timer;

    [SerializeField]
    float maxTime;

    float _currentTime;

    private void Start()
    {
        _currentTime = maxTime;
    }

    private void Update()
    {
        _currentTime -= Time.deltaTime;
        if(_currentTime < 0)
        {
            Die();
        }

        timer.fillAmount = _currentTime / maxTime;
    }
    private void Die()
    {

        animator.SetTrigger("dead");
        StartCoroutine(DisableMovement()); // Deshabilita el movimiento del jugador
    }

    private IEnumerator DisableMovement()
    {
        // Desactiva el script PlayerController2D
        playerController.enabled = false;
        playerHealth.TakeDamage(playerHealth.currentHealth);
        yield return new WaitForSeconds(1.5f); // Espera antes de desactivar el objeto
        gameObject.SetActive(false);

        timeOut.gameObject.SetActive(true);
    }

}
