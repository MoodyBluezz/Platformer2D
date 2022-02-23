using UnityEngine;

namespace Platformer2D.Enemy
{
    public class EnemyChase : EnemyController
    {
        public float distanceBetweenEnemyAndPlayer;
        public float enemySpeed;
        private Transform _playerPosition;
        private Vector2 _currentPosition;

        private void Start()
        {
            _playerPosition = _player.GetComponent<Transform>();
            _currentPosition = GetComponent<Transform>().position;
        }
    
        private void Update()
        {
            EnemyChasePlayer();
        }

        private void EnemyChasePlayer()
        {
            if (Vector2.Distance(transform.position, _playerPosition.position) < distanceBetweenEnemyAndPlayer)
            {
                transform.position = Vector3.MoveTowards(transform.position, _playerPosition.position, enemySpeed * Time.deltaTime);
                transform.eulerAngles = new Vector3(0, 180, 0);
                _enemyAnimator.SetBool("isWalking", true);
            }
            else
            {
                if (Vector2.Distance(transform.position, _currentPosition) <= 0)
                {
                    _enemyAnimator.SetBool("isWalking", false);
                }
                else
                {
                    transform.position =
                        Vector2.MoveTowards(transform.position, _currentPosition, enemySpeed * Time.deltaTime);
                    _enemyAnimator.SetBool("isWalking", true);
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    if (transform.position.Equals(_currentPosition))
                    {
                        transform.eulerAngles = new Vector3(0, 180, 0);
                    }
                }
            }
        }
    }
}
