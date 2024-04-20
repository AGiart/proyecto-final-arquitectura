using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class DistanceAttackController : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    LayerMask playerLayer;

    [SerializeField]
    int damagePerHit = 10; // Daño por golpe

    [SerializeField]
    Transform attackPoint;

    [SerializeField]
    Transform target;

    [SerializeField]
    float distanceToTarget;

    [SerializeField]
    float attackRange;

    [SerializeField]
    float attackRate;

    private bool playerAlive = true;

    [SerializeField]
    private PlayerHealthController _playerHealth;
    [SerializeField]
    private PatrolController _patrol;

    private float oldSpeed;

    private float _nextAttackTime;


    private void FixedUpdate()
    {
        if (_patrol.speed != 0)
        {
            oldSpeed = _patrol.speed;
        }


        if (_playerHealth.currentHealth <= 0)
        {
            playerAlive = false;
        }
        float distance = Vector2.Distance(transform.position, target.position);
        if (distance <= distanceToTarget)
        {
            animator.SetBool("Walk", false);
            _patrol.speed = 0.0f;
            if (playerAlive)
            {
                if (Time.time >= _nextAttackTime)
                {
                    animator.SetTrigger("Attack");
                    Attack(); // Llamar al método Attack para hacer daño al jugador
                    _nextAttackTime = Time.time + attackRange / attackRate;
                }
            }
        }
        else
        {
            animator.SetBool("Walk", true);
            _patrol.speed = oldSpeed;
        }
    }

    void Attack()
    {
        
        animator.SetTrigger("Attack");

        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        
        foreach (Collider2D player in hitPlayer)
        {
            // Aplicar daño al jugador
            player.GetComponent<PlayerHealthController>().TakeDamage(damagePerHit);
        }
        
    }
}