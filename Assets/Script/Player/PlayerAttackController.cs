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
    int damagePerHit = 10; // Da�o por golpe

    private float nextAttackTime = 0f;

    public bool canMove = true;

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
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            // Aplicar da�o al enemigo
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
