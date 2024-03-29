using System;
using Platformer2D.Ability;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer2D.Player
{
	public class PlayerController : MonoBehaviour
	{
		public GameObject gameOverPanel;
		public GameObject winPanel;
		public float jumpForce;
		public float runSpeed;
		public LayerMask groundMask;
		private Rigidbody2D _playerRigidbody;
		private Collider2D _playerCollider;
		private Animator _playerAnimator;
		private float _movementInput;

		private void Start()
		{
			_playerRigidbody = GetComponent<Rigidbody2D>();
			_playerCollider = GetComponent<Collider2D>();
			_playerAnimator = GetComponent<Animator>();
		}

		private void Update()
		{
			_movementInput = Input.GetAxisRaw("Horizontal");

			PlayerMovement();
			PlayerJump();
        
			if (Input.GetKeyDown(KeyCode.R))
			{
				SceneManager.LoadScene(1);
			}
		}

		private void OnTriggerEnter2D(Collider2D col)
		{
			if (col.name.Equals("Checkpoint"))
			{
				col.GetComponent<Animator>().SetTrigger("onFinish");
				winPanel.SetActive(true);
			}
		}

		private void OnTriggerStay2D(Collider2D other)
		{
			if (other.tag.Equals("Enemy"))
			{
				if (!PlayerAbilities._isSkillUsed)
					PlayerDeath();
			}
		}

		private void PlayerJump()
		{
			var inputKey = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
			if (IsGrounded() && inputKey)
			{
				_playerRigidbody.velocity = Vector2.up * jumpForce;
			}
			_playerAnimator.SetBool("isJumping", !IsGrounded());
		}

		private void PlayerDeath()
		{
			_playerCollider.enabled = false;
			_playerAnimator.SetTrigger("playerDeath");
			gameOverPanel.SetActive(true);
			ResetAllStaticDependencies();
		}

		private void ResetAllStaticDependencies()
		{
			PlayerAbilities._isSkillUsed = false;
			PickUpAbility._isAbilityPickedUp = false;
		}

		private void PlayerMovement()
		{
			_playerRigidbody.velocity = new Vector2(_movementInput * runSpeed, _playerRigidbody.velocity.y);

			_playerAnimator.SetBool("isRunning", _movementInput != 0);

			transform.eulerAngles = _movementInput < 0 ? new Vector3(0, 180, 0) : new Vector3(0, 0, 0);
		}

		private bool IsGrounded()
		{
			const float distance = .1f;
			var raycastHit = Physics2D.BoxCast(_playerCollider.bounds.center, _playerCollider.bounds.size, 0f, Vector2.down, distance, groundMask);
			return raycastHit.collider != null;
		}
	}
}
