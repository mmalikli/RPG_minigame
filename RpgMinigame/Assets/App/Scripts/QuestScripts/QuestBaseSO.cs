using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;

public class QuestBaseSO : ScriptableObject
{

  private void OnEnable() {
    //Debug.Log("Hello");
    EventManager.Instance.AddListener<OnQuestCompletedEvent>(OnQuestCompletedEventHandler); 
  }
  private void OnDisable() {
    EventManager.Instance.RemoveListener<OnQuestCompletedEvent>(OnQuestCompletedEventHandler);
  }

  public string questName;

  [TextArea(3,10)]
  public string questDescription;
  // NOTE: THIS WORKS FOR ONLY ONE ENEMY TYPE!!!!


  // Current Amount shows us a progress of our quest
  public int[] CurrentAmount { get; set; }
  // Required Amount shows us a required amount of monsters
  public int[] RequiredAmount { get; set; }
// 24 min +++ ???
  //public bool IsCompleted { get; set; } //??
  public bool IsCompleted = false;

  public CharacterProfile questGivenNPC;//???
  public DialogueBase completedQuestDialogue;

  [System.Serializable]
  public class QuestRewards {
    public ItemBaseSO itemReward;
    public int experienceReward;
    public int goldReward;
  }
  public QuestRewards rewards;

  public virtual void StartQuest() {
    //if(!QuestManager.instance.inQuest) return;

    CurrentAmount = new int[RequiredAmount.Length];

  }

  // protected void Evaluate() {
  //   //if(IsCompleted) return;
  //   //Debug.Log("Required Amount from Evaluate"+RequiredAmount[0]);
  //   //Debug.Log("Current Amount from Evaluate"+CurrentAmount[0]);
  //   for (int i = 0; i < RequiredAmount.Length; i++)
  //   {
  //     if(CurrentAmount[i]< RequiredAmount[i]) return;
  //     else if (CurrentAmount[i] != 0 && CurrentAmount[i] == RequiredAmount[i]) {
  //       Debug.Log("Quest is Completed");
  //       IsCompleted = true;       
  //     //  Debug.Log(questName);
  //       for (int j = 0; j < GameManager.instance.allDialogueTriggers.Length; j++)
  //       {
  //         if (GameManager.instance.allDialogueTriggers[i].currentNPC == questGivenNPC) {
  //           GameManager.instance.allDialogueTriggers[i].HasCompletedQuest = true;
  //           GameManager.instance.allDialogueTriggers[i].CompletedQuestDialogue = completedQuestDialogue;
  //           return;
  //           //break;
  //         }// } else {
  //         //   GameManager.instance.allDialogueTriggers[i].HasCompletedQuest = false;
  //         //   //return;
  //         // }
  //       }
  //     }
  //   }
  // }

  private void OnQuestCompletedEventHandler(OnQuestCompletedEvent eventDetails) {
    if(questGivenNPC != eventDetails.completedQuest.questGivenNPC) return;
    //if (!QuestManager.instance.inQuest) return;
    // Debug.Log("Completed Quest"+eventDetails.completedQuest.questName);
    // Debug.Log("OnQuestRewardClaimed Event Raised");
    // Debug.Log(rewards.itemReward.itemName);
    //QuestManager.instance.inQuest = false;
    EventManager.Instance.Raise(new OnQuestRewardClaimedEvent(questName,rewards.itemReward,0,0));
  }

}
