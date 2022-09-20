using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBaseSO : ScriptableObject
{

  public string questName;

  [TextArea(3,10)]
  public string questDescription;
  // NOTE: THIS WORKS FOR ONLY ONE ENEMY TYPE!!!!

  
  // Current Amount shows us a progress of our quest
  public int[] CurrentAmount { get; set; }
  // Required Amount shows us a required amount of monsters
  public int[] RequiredAmount { get; set; }
// 24 min +++ ???
  public bool IsCompleted { get; set; } //??

  public CharacterProfile questGivenNPC;//???
  public DialogueBase completedQuestDialogue;



  public virtual void StartQuest() {

    CurrentAmount = new int[RequiredAmount.Length];

  }

  protected void Evaluate() {
    //Debug.Log("Required Amount from Evaluate"+RequiredAmount[0]);
    //Debug.Log("Current Amount from Evaluate"+CurrentAmount[0]);
    for (int i = 0; i < RequiredAmount.Length; i++)
    {
      if(CurrentAmount[i]< RequiredAmount[i]) return;
      else if (CurrentAmount[i] != 0 && CurrentAmount[i] == RequiredAmount[i]) {
        Debug.Log("Quest is Completed");
        for (int j = 0; j < GameManager.instance.allDialogueTriggers.Length; j++)
        {
          if (GameManager.instance.allDialogueTriggers[i].currentNPC == questGivenNPC) {
            GameManager.instance.allDialogueTriggers[i].HasCompletedQuest = true;
            GameManager.instance.allDialogueTriggers[i].CompletedQuestDialogue = completedQuestDialogue;
            return;
            //break;
          }
        }
      }
    }

  }

}
