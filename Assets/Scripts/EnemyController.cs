using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public GameObject abilityPrefab;
	private Collider2D _enemyCollider;
	private Animator _enemyAnimator;

	private void Start()
	{
		_enemyCollider = GetComponent<Collider2D>();
		_enemyAnimator = GetComponent<Animator>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log(collision.name);
		if (collision.name.Equals("Player"))
		{
			EnemyDeath(collision);
			SpawnAbilityAfterDeath();
		}
	}

	private void EnemyDeath(Collider2D collision)
	{
		if (collision.bounds.Intersects(_enemyCollider.bounds))
		{
			_enemyAnimator.SetTrigger("tookDamage");
			_enemyCollider.enabled = false;
			GetComponent<CircleCollider2D>().enabled = false;
		}
	}

	private void SpawnAbilityAfterDeath()
	{
		var newAbility = Instantiate(abilityPrefab);
		newAbility.name = "Invisibility";
	}
}
