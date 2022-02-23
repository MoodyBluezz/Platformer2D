using TMPro;
using UnityEngine;

namespace Platformer2D.DialogueSystem
{
    public class Dialogue : MonoBehaviour
    {
        public GameObject dialogueObject;
        public TextMeshProUGUI dialogueText;

        public string GetQuestionDialogueText()
        {
            return 	dialogueText.text = $"Press \"E\" to learn the spell";
        }
        
        public string GetAbilityDialogueText(string abilityName)
        {
            return 	dialogueText.text = $"You learned {abilityName} skill!";
        }

        public string GetEnemyDialogueText()
        {
            return dialogueText.text = $"I'm glad that I found this ability, otherwise I would die...";
        }

        public void DialogueStateControl(bool isActive)
        {
            dialogueObject.SetActive(isActive);
        }
    }
}
