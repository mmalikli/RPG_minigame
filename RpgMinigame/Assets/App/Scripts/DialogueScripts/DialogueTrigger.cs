using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : Interactable
{
  [Header("This NPC")]
  [Tooltip("This is current NPC's profile")]
  public CharacterProfile currentNPC;

  public DialogueBase dialogueArray;

  public override void Interact()
  {
    if(!DialogueManager.instance.isPlayerInDialogue || !DialogueManager.instance.isPlayerInDialogueOption) {
      DialogueManager.instance.EnqueueDialogue(dialogueArray);
    }
  }

}
