using UnityEngine;

namespace Platformer2D.Enemy
{
	public class EnemyController : MonoBehaviour
	{
		public GameObject _player;
		public Collider2D _enemyCollider;
		public Animator _enemyAnimator;

		private void Start()
		{
			_enemyCollider = GetComponent<Collider2D>();
			_enemyAnimator = GetComponent<Animator>();
		}
	}
}
