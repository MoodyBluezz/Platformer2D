using System;
using UnityEngine;

namespace Platformer2D.Ability
{
	public class PickUpAbility : MonoBehaviour
	{
		public static string AbilityName { get; set; }
		public static bool _isAbilityPickedUp = false;

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.tag.Equals("Ability"))
			{
				AbilityName = collision.name;
				_isAbilityPickedUp = true;
			}
		}
	}
}
