using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float runSpeed;
    public float jumpTimeCounter;
    public float jumpTime;
    public float checkRadius;
    public LayerMask groundMask;
    public Transform groundPosition;
    private Rigidbody2D _playerRigidbody;
	private Collider2D _playerCollider;
    private Animator _playerAnimator;
    private bool _isGrounded = false;
    private bool _isJumping = false;
	private bool _isDoubleJump = false;
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
    }

    private void PlayerJump()
	{
		if (IsGrounded() && Input.GetKeyDown(KeyCode.W))
		{
			_isJumping = true;
			jumpTimeCounter = jumpTime;
			_playerRigidbody.velocity = Vector2.up * jumpForce;
		}

		if (IsGrounded())
			_playerAnimator.SetBool("isJumping", false);
		else
			_playerAnimator.SetBool("isJumping", true);

		if (Input.GetKeyDown(KeyCode.W) && _isJumping)
		{
			if (jumpTimeCounter > 0)
			{
				_playerRigidbody.velocity = Vector2.up * jumpForce;
				jumpTimeCounter -= Time.deltaTime;
			}
			else
			{
				_isJumping = false;
			}
		}
	}

    private void PlayerMovement()
	{
        _playerRigidbody.velocity = new Vector2(_movementInput * runSpeed, _playerRigidbody.velocity.y);

        if (_movementInput == 0)
            _playerAnimator.SetBool("isRunning", false);
        else
            _playerAnimator.SetBool("isRunning", true);

        if (_movementInput < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);
		else
            transform.eulerAngles = new Vector3(0, 0, 0);
	}

	private bool IsGrounded()
	{
		var distance = .1f;
		var raycastHit = Physics2D.BoxCast(_playerCollider.bounds.center, _playerCollider.bounds.size, 0f, Vector2.down, distance, groundMask);
		return raycastHit.collider != null;
	}
}
