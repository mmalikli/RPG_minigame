using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : Interactable
{
  [Header("Basic Dialogue info")]
  [Header("This NPC")]
  [Tooltip("This is current NPC's profile")]
  public CharacterProfile currentNPC;

  // nextDialogueOnInteract ??
  // public int index;
  public DialogueBase dialogueArray;
  public bool HasCompletedQuest { get; set;}
  public DialogueBase CompletedQuestDialogue {get; set;}

  public override void Interact()
  {
    if(!DialogueManager.instance.isPlayerInDialogue || !DialogueManager.instance.isPlayerInDialogueOption) {
      if(HasCompletedQuest) {
        DialogueManager.instance.EnqueueDialogue(CompletedQuestDialogue);
        HasCompletedQuest = false;
        return;
      }
      DialogueManager.instance.EnqueueDialogue(dialogueArray);
    }
  }

}
