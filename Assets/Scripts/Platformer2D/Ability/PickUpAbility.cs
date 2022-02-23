using UnityEngine;

namespace Platformer2D.Ability
{
	public class PickUpAbility : MonoBehaviour
	{
		public string abilityName;
		public static string AbilityName { get; set; }
		public static bool _isColliding = false;
		public static bool _isAbilityPickedUp = false;

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.name.Equals("Player"))
			{
				AbilityName = abilityName;
				_isColliding = true;
			}
		}

		private void Update()
		{
			if (_isColliding && Input.GetKeyDown(KeyCode.E))
			{
				_isAbilityPickedUp = true;
			}
		}
	}
}
