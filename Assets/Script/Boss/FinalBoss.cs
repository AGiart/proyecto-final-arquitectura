using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb2D;
    public Transform playerNinja;
    private bool isLookingRight = true;

    [Header("Movement")]
    [SerializeField] 
    private float moveSpeed;

    [Header("Health")]
    [SerializeField] 
    private float healthGolem;

    [SerializeField] 
    private HealthBarGolem healthBarGolem;

    [Header("Ataque")]
    [SerializeField]
    private Transform Attack;

    [SerializeField]
    private float radioAtaque;

    [SerializeField]
    private int danoAtaque;

    [SerializeField] 
    private float detectionRange = 5f;

    public GameObject HealthBarGolem;



    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        healthBarGolem.StartHealthBar(healthGolem);
        playerNinja = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        

        // Calcula la distancia entre el jefe final y el jugador
        float distanceToPlayer = Vector2.Distance(transform.position, playerNinja.position);
        animator.SetFloat("DistancePlayer", distanceToPlayer);

        // Comprueba si el jugador está dentro del rango de detección
        if (distanceToPlayer <= detectionRange)
        {
            //Dentro de este if se podría hacer visible la barra de vida
            //y se podría poner un efecto de sonido por iniciar la batalla con el jefe

            //HealthBarGolem.gameObject.SetActive(true);

            LookPlayer();
            MoveTowardsPlayer();
        }

    }

    private void MoveTowardsPlayer()
    {
        Vector2 targetDirection = (playerNinja.position - transform.position).normalized;
        rb2D.velocity = targetDirection * moveSpeed;

        // Flip the sprite if necessary
        if ((targetDirection.x > 0 && !isLookingRight) || (targetDirection.x < 0 && isLookingRight))
        {
            FlipSprite();
        }
    }

    private void FlipSprite()
    {
        isLookingRight = !isLookingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    public void TakeDamage(float damage)
    {
        healthGolem -= damage;
        healthBarGolem.ChangeCurrentHealth(healthGolem);

        if (healthGolem <= 0)
        {
            animator.SetTrigger("Dead");
        }
    }

    private void DeadGolem()
    {
        Destroy(gameObject);
    }

    private void LookPlayer()
    {
        if (playerNinja.position.x > transform.position.x && !isLookingRight)
        {
            FlipSprite();
        }
        else if (playerNinja.position.x < transform.position.x && isLookingRight)
        {
            FlipSprite();
        }
    }

    public void Ataque()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(Attack.position, radioAtaque);

        foreach (Collider2D colision in objetos)
        {
            if (colision.CompareTag("Player"))
            {
                colision.GetComponent<PlayerHealthController>().TakeDamage(danoAtaque);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Attack.position, radioAtaque);
    }
}

