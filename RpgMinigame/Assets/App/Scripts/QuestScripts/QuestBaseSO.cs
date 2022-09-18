using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBaseSO : ScriptableObject
{
  public string questName;

  [TextArea(3,10)]
  public string questDescription;
  
  // Current Amount shows us a progress of our quest
  public int[] CurrentAmount { get; set; }
  // Required Amount shows us a required amount of monsters
  public int[] RequiredAmount { get; set; }
// 24 min +++ ???
  public bool IsCompleted { get; set; }

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
      }
    }

  }

}
