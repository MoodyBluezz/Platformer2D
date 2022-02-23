using Platformer2D.Ability;
using UnityEngine;

namespace Platformer2D.Player
{
	public class PlayerAbilities : MonoBehaviour
	{
		public GameObject meteor;
		public float dashSpeed;
		public float dashLength = .5f;
		public float dashCooldown = 5f;
		public float moveSpeed = 1f;
		private float _dashCounter;
		private float _dashCooldownCounter;
		private PlayerController _playerController;
		private Animator _playerAnimator;
		private SpriteRenderer _playerSprite;
		private float _time = 0f;
		private Color _playerColor;
		public static bool _isSkillUsed = false;
		private bool _isInvisibleAbility = false;
		private bool _isMeteorAbility = false;
		private bool _isMeteorAbilityPicked = false;

		private void Start()
		{
			_playerController = GetComponent<PlayerController>();
			_playerAnimator = GetComponent<Animator>();
			_playerSprite = GetComponent<SpriteRenderer>();
			_playerColor = _playerSprite.color;
			moveSpeed = _playerController.runSpeed;
		}

		private void Update()
		{
			DashAbility();
			InvisibilityAbility();
			MeteorAbility();
		}

		private void InvisibilityAbility()
		{
			if (PickUpAbility._isAbilityPickedUp)
				_isInvisibleAbility = true;

			if (Input.GetKeyDown(KeyCode.I) && _isInvisibleAbility)
			{
				_isSkillUsed = true;
				_playerColor.a = 0.2f;
				_playerSprite.color = _playerColor;
			}

			if (!_isSkillUsed) return;
			_time += 1 * Time.deltaTime;
			if (!(_time >= 5)) return;
			_isSkillUsed = false;
			_playerColor.a = 1f;
			_playerSprite.color = _playerColor;
			_time = 0;
		}

		private void MeteorAbility()
		{
			if (PickUpAbility._isAbilityPickedUp)
				_isMeteorAbilityPicked = true;
			
			if (Input.GetKeyDown(KeyCode.M) && _isMeteorAbilityPicked)
			{
				meteor = Instantiate(meteor);
				meteor.transform.position = new Vector3(transform.position.x, 1, transform.position.z);
				_isMeteorAbility = true;
			}

			if (_isMeteorAbility)
			{
				meteor.transform.position = Vector3.Lerp(meteor.transform.position, new Vector3(transform.position.x + 1, 0, 0), 4 * Time.deltaTime);
			}
		}

		private void DashAbility()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				if (_dashCooldownCounter <= 0 && _dashCounter <= 0)
				{
					_playerAnimator.SetBool("isDashing", true);
					_playerController.runSpeed = dashSpeed;
					_dashCounter = dashLength;
				}
			}

			if (_dashCounter > 0)
			{
				_dashCounter -= Time.deltaTime;
				if (_dashCounter <= 0)
				{
					_playerAnimator.SetBool("isDashing", false);
					_playerController.runSpeed = moveSpeed;
					_dashCooldownCounter = dashCooldown;
				}
			}

			if (_dashCooldownCounter > 0)
			{
				_dashCooldownCounter -= Time.deltaTime;
			}
		}
	}
}
