using UnityEngine;

namespace Platformer2D.Ability
{
    public class PickedUpAbilities : MonoBehaviour
    {
        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.tag.Equals("Ability") && PickUpAbility._isAbilityPickedUp)
            {
                Destroy(other.gameObject);
                ResetAllStaticDependencies();
            }
        }
    
        private void ResetAllStaticDependencies()
        {
            PickUpAbility._isColliding = false;
            PickUpAbility._isAbilityPickedUp = false;
        }
    }
}
