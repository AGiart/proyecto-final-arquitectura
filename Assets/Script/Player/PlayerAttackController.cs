using System.Collections;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    Transform attackPoint;

    [SerializeField]
    LayerMask enemyLayer;

    [SerializeField]
    float attackRange = 0.5f;

    [SerializeField]
    float attackRate = 2f;

    [SerializeField]
    int damagePerHit = 10; // Daño por golpe

    private float nextAttackTime = 0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    void Attack()
    {
        animator.SetTrigger("attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            // Aplicar daño al enemigo
            enemy.GetComponent<EnemyHealthController>().TakeDamage(damagePerHit);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
