using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : Interactable
{
  // private void OnEnable() {
  //   //Debug.Log("Trigger");
  // }
  [Header("Basic Dialogue info")]
  [Header("This NPC")]
  [Tooltip("This is current NPC's profile")]
  public CharacterProfile currentNPC;

  // nextDialogueOnInteract ??
  // public int index;
  public DialogueBase dialogueArray;
  public bool HasCompletedQuest;
  public DialogueBase CompletedQuestDialogue;

  public override void Interact()
  {
    if(!DialogueManager.instance.isPlayerInDialogue || !DialogueManager.instance.isPlayerInDialogueOption) {
      Debug.Log(CompletedQuestDialogue.completedQuest.questName);
      if(HasCompletedQuest) {
        //Debug.Log
        DialogueManager.instance.EnqueueDialogue(CompletedQuestDialogue);
        HasCompletedQuest = false;
        //QuestManager.instance.CurrentQuest = null;
        return;
      }
      DialogueManager.instance.EnqueueDialogue(dialogueArray);
    }
  }

}
