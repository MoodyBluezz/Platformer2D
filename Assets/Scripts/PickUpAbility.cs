using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAbility : MonoBehaviour
{
	public static bool _isColliding = false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.name.Equals("Player"))
		{
			_isColliding = true;
		}
	}

	private void Update()
	{
		if (_isColliding && Input.GetKeyDown(KeyCode.E))
		{
			Destroy(this.gameObject);
		}
	}
}
