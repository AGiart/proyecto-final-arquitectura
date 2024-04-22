using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpecial : MonoBehaviour
{

    [SerializeField]
    private int damage;

    [SerializeField]
    private Vector2 dimensionesCaja;

    [SerializeField]
    Transform posicionCaja;

    [SerializeField]
    private float tiempoDeVida;



    private void Start()
    {
        Destroy(gameObject, tiempoDeVida);
    }

    private void Hit()
    {
        Collider2D[] objetos = Physics2D.OverlapBoxAll(posicionCaja.position, dimensionesCaja, 0f);

        foreach (Collider2D colisiones in objetos)
        {
            if (colisiones.CompareTag("Player"))
            {
                colisiones.GetComponent<PlayerHealthController>().TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(posicionCaja.position, dimensionesCaja);
    }
}
