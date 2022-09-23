using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;

public class QuestDialogueTrigger : DialogueTrigger
{
  private void OnEnable() {
    EventManager.Instance.AddListener<OnQuestAcceptedEvent>(OnQuestAcceptedEventHandler);
  }
  private void OnDisable() {
    EventManager.Instance.RemoveListener<OnQuestAcceptedEvent>(OnQuestAcceptedEventHandler);
  }
  [Header("Quest Dialogue info")]
  public bool hasActiveQuest;
  public DialogueQuestSO[] dialogueQuests;
  public int QuestIndex;

  public override void Interact()
  {
    if (hasActiveQuest) {
      DialogueManager.instance.EnqueueDialogue(dialogueQuests[QuestIndex]);
    } else {
      base.Interact();
    }
    //base.Interact();
  }
  private void OnQuestAcceptedEventHandler(OnQuestAcceptedEvent eventDetails) {
//    Debug.Log(eventDetails.acceptedQuest.questName);
  //  Debug.Log(dialogueQuests[QuestIndex].quest.questName);
    if(eventDetails.acceptedQuest.questGivenNPC != currentNPC) return;
    //Debug.Log(eventDetails.acceptedQuest.questName);
    hasActiveQuest = false;
  }
}
