using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendController : MonoBehaviour
{

	[SerializeField]
	Animator animator;

	[SerializeField]
	Transform target;

	public PatrolController _patrolcontroller;

	public float oldSpeed;

	private void FixedUpdate()
	{

		if (_patrolcontroller.speed != 0)
		{
			oldSpeed = _patrolcontroller.speed;
		}

	}
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			_patrolcontroller.speed = 0.0F;
			animator.SetBool("Attack", false);
			animator.SetBool("Defend", true);
			Defender();
		}

	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			animator.SetBool("Defend", false);
			_patrolcontroller.speed = oldSpeed;
		}
	}

	private void Defender()
	{

	}
}
