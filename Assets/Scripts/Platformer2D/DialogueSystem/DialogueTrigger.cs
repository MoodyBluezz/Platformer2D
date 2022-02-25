using System;
using Platformer2D.Ability;
using Platformer2D.Player;
using UnityEngine;

namespace Platformer2D.DialogueSystem
{
    public class DialogueTrigger : MonoBehaviour
    {
        private Dialogue _dialogue;
        private bool _isAbilityPicked = false;
        private float _time = 0f;
        private readonly Vector3 _showTextAlwaysFromLeftToRight = new Vector3(0, 0, 0);

        private void Start()
        {
            _dialogue = GetComponent<Dialogue>();
        }

        private void Update()
        {
            _dialogue.dialogueObject.transform.eulerAngles = _showTextAlwaysFromLeftToRight;
            ResetDialogueAfterAbilityPicked();
        }

        private void ResetDialogueAfterAbilityPicked()
        {
            if (!_isAbilityPicked) return;
            _time += 1 * Time.deltaTime;
            if (!(_time > 3)) return;
            _time = 0;
            _isAbilityPicked = false;
            _dialogue.DialogueStateControl(false);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag.Equals("Enemy") && PlayerAbilities._isSkillUsed)
            {
                _dialogue.DialogueStateControl(true);
                _dialogue.GetEnemyDialogueText();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _dialogue.DialogueStateControl(false);

            if (!PickUpAbility._isAbilityPickedUp) return;
            _isAbilityPicked = true;
            PickUpAbility._isAbilityPickedUp = false;
            _dialogue.DialogueStateControl(true);
            _dialogue.GetAbilityDialogueText(PickUpAbility.AbilityName);
        }
    }
}
