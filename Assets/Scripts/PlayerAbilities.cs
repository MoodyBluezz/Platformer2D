using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public float dashSpeed;
	public float dashLength = .5f;
    public float dashCooldown = 5f;
    public float moveSpeed = 1f;
	private float _dashCounter;
    private float _dashCooldownCounter;
	private PlayerController _playerController;
	private Animator _playerAnimator;

	private void Start()
	{
        _playerController = GetComponent<PlayerController>();
		_playerAnimator = GetComponent<Animator>();
		moveSpeed = _playerController.runSpeed;
    }

	private void Update()
	{
		DashAbility();
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
