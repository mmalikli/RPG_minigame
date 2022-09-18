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
    for (int i = 0; i < RequiredAmount.Length; i++)
    {
      if(CurrentAmount[i]< RequiredAmount[i]) return;
    }

    Debug.Log("Quest is Completed");
  }

}
