using System;
using UnityEngine;

namespace Platformer2D.Ability
{
    public class MeteorStrikeExplosion : MonoBehaviour
    {
        public GameObject explosionEffectMeteor;
        private Collider2D _meteorCollider;

        private void Start()
        {
            _meteorCollider = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag.Equals("Enemy"))
            {
                var explosion = Instantiate(explosionEffectMeteor, transform.position, Quaternion.identity);
                Destroy(explosion, 2);
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.tag.Equals("Enemy") && 
                col.collider.bounds.Intersects(_meteorCollider.bounds))
            {
                Destroy(col.gameObject);
            }
        }
    }
}
