using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLogView : MonoBehaviour
{
  // private void OnEnable() {
  // //Debug.Log("Log awake");
  // for (int i = 0; i < ; i++)
  // {
    
  // }  
  // }
  
  [Header("Controller reference")]
  [SerializeField] private QuestLogController questLogController;

  [SerializeField] private Text questName;
  [SerializeField] private Text questDescription;
   public GameObject questLogUI;
  [SerializeField] private GameObject questButtonPrefab;
  [SerializeField] private Transform content;
  //[SerializeField] private Toggle isQuestFinished;
   [HideInInspector] public List<QuestBaseSO> QuestsInLog = new List<QuestBaseSO>();
  [HideInInspector] public List<QuestBaseSO> completedQuests = new List<QuestBaseSO>();

  public void SetQuestLogUI(QuestBaseSO quest) {
    questName.text = quest.questName;
    questDescription.text = quest.questDescription;
  }
  public void AddQuestToLog(QuestBaseSO quest) {
    var questButton = Instantiate(questButtonPrefab, content);
    questButton.GetComponent<QuestLogButton>().SetQuest(quest);
    QuestsInLog.Add(quest);
  }
  // <public void OnQuestLogButtonPressed() {
  //   QuestLogView questLog = GetComponent<QuestLogButton>().quest;
  //   SetQuestLogUI(quest);
  // }>
  
  public void SetQuestToggle(QuestBaseSO quest) {
  //   //isQuestFinished.isOn = true;
  //bu
  //completedQuests
  //if(QuestsInLog.Contains(quest)) {
  var buttons = GetComponentsInChildren<QuestLogButton>();
  for (int i = 0; i < buttons.Length; i++)
  {
    if(buttons[i].quest == quest) {
    buttons[i].questEnd = true;buttons[i].setToggle();
    break;
    }
  }
  //}
}

}
