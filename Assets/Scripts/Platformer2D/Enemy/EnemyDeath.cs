using UnityEngine;

namespace Platformer2D.Enemy
{
    public class EnemyDeath : EnemyController
    {
        public GameObject abilityPrefab;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(collision.name);
            if (collision.name.Equals(_player.name))
            {
                Death(collision);
                SpawnAbilityAfterDeath();
            }
        }

        private void Death(Collider2D collision)
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
}
