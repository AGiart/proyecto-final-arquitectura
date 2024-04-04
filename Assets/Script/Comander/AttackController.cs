using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class AttackController : MonoBehaviour
{
	[SerializeField]
	Animator animator;

	[SerializeField]
	Transform target;


	[SerializeField]
	float attackRate = 1;

	private float _nextAttackTime;
	private int _nextAttack = 0;


	public PatrolController _patrolcontroller;


	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			_patrolcontroller.speed = 0.0F;
			animator.SetBool("Attack", true);
			animator.SetBool("Defend", false);
			Atacar();
		}

	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			if (_nextAttack <= 2 || _nextAttack > 2)
			{
				_nextAttack = 0;
			}
		}
	}

	public  void Atacar()
	{

		if (Time.time >= _nextAttackTime)
		{
			_nextAttackTime = Time.time + 2 / attackRate;
			animator.SetInteger("AttackNum", _nextAttack);

			Debug.Log(_nextAttack);
			_nextAttack++;
		}
	}

}
