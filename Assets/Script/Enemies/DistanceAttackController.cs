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
    float attackRange = 1.0F;

    [SerializeField]
    float attackRate = 1;

    private bool playerAlive = true;

    [SerializeField]
    private PlayerHealthController _playerHealth;

    private float _nextAttackTime;

    private void FixedUpdate()
    {
        if (_playerHealth.currentHealth <= 0)
        {
            playerAlive = false;
        }
        float distance = Vector2.Distance(transform.position, target.position);
        if (distance <= distanceToTarget)
        {
           if (playerAlive)
            {
                if (Time.time >= _nextAttackTime)
                {
                    animator.SetTrigger("attack");
                    Attack(); // Llamar al método Attack para hacer daño al jugador
                    _nextAttackTime = Time.time + attackRange / attackRate;
                }
            }
        }
    }

    void Attack()
    {
        animator.SetTrigger("attack");

        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        
        foreach (Collider2D player in hitPlayer)
        {
            // Aplicar daño al jugador
            player.GetComponent<PlayerHealthController>().TakeDamage(damagePerHit);
        }
    }
}