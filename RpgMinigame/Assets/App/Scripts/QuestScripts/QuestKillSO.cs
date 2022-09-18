using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;

[CreateAssetMenu(fileName = "New Kill Quest", menuName ="Quests/Kill Quest")]
public class QuestKillSO : QuestBaseSO
{
  private void OnEnable() {
    //Debug.Log("Kill Quest!!!");
    EventManager.Instance.AddListener<OnEnemyDeathEvent>(OnEnemyDeathEventHandler);
  }
  private void OnDisable() {

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

  private void OnEnemyDeathEventHandler(OnEnemyDeathEvent eventDetails) {
    for (int i = 0; i < objectives.Length; i++)
    {
      if (eventDetails.enemyProfile == objectives[i].requiredEnemy){
        CurrentAmount[i]++;
      }
    }
    Evaluate();
  }
}

