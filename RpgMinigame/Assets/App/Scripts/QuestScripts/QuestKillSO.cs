using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;

[CreateAssetMenu(fileName = "New Kill Quest", menuName ="Quests/Kill Quest")]
public class QuestKillSO : QuestBaseSO
{
  private void OnEnable() {
    //Debug.Log("Kill Quest!!!");
    EventManager.Instance.AddListener<OnQuestCompletedEvent>(OnQuestCompletedEventHandler); 
    EventManager.Instance.AddListener<OnEnemyDeathEvent>(OnEnemyDeathEventHandler);
  }
  private void OnDisable() {
    EventManager.Instance.RemoveListener<OnQuestCompletedEvent>(OnQuestCompletedEventHandler);
    EventManager.Instance.RemoveListener<OnEnemyDeathEvent>(OnEnemyDeathEventHandler);
  }
  [System.Serializable]
  public class Objective {
    public EnemyProfile requiredEnemy;
    public int requiredAmount;
  }

  public Objective[] objectives;

  public override void StartQuest() {
    //Debug.Log("Quest Started QK_SO");
    if(objectives.Length == 0) return;

    RequiredAmount = new int[objectives.Length];
    
    for(int i = 0; i<objectives.Length; i++) {
      RequiredAmount[i] = objectives[i].requiredAmount;
    }
    base.StartQuest();
  }
    protected void Evaluate() {
    //if(IsCompleted) return;
    Debug.Log("Required Amount from Evaluate"+RequiredAmount[0]);
    Debug.Log("Current Amount from Evaluate"+CurrentAmount[0]);
    for (int i = 0; i < RequiredAmount.Length; i++)
    {

      if(CurrentAmount[i]< RequiredAmount[i]) return;
      else if (CurrentAmount[i] != 0 && CurrentAmount[i] == RequiredAmount[i]) {
        Debug.Log("Quest is Completed");
        IsCompleted = true;       
      //  Debug.Log(questName);
        for (int j = 0; j < GameManager.instance.allDialogueTriggers.Length; j++)
        {
          //Debug.Log(GameManager.instance.allDialogueTriggers)
          if (GameManager.instance.allDialogueTriggers[j].currentNPC == questGivenNPC) {
            GameManager.instance.allDialogueTriggers[j].HasCompletedQuest = true;
            GameManager.instance.allDialogueTriggers[j].CompletedQuestDialogue = completedQuestDialogue;
            //return;
            break;
          }// } else {
          //   GameManager.instance.allDialogueTriggers[i].HasCompletedQuest = false;
          //   //return;
          // }
        }
      }
    }
  }

  private void OnEnemyDeathEventHandler(OnEnemyDeathEvent eventDetails) {
    if(objectives.Length <= 0) return;
    
    for (int i = 0; i < objectives.Length; i++)
    {
      if (eventDetails.enemyProfile == objectives[i].requiredEnemy){
        if(CurrentAmount == null) return;
        CurrentAmount[i]++;
        //Debug.Log(CurrentAmount);
      }
    }
    Evaluate();
  }

  //private
  private void OnQuestCompletedEventHandler(OnQuestCompletedEvent eventDetails) {
    //Debug.Log("OnQuestRewardClaimed Event Raised");
    //Debug.Log(rewards.itemReward.itemName);
    if(questGivenNPC != eventDetails.completedQuest.questGivenNPC) return;
    EventManager.Instance.Raise(new OnQuestRewardClaimedEvent(questName,rewards.itemReward,0,0));
  }
}

