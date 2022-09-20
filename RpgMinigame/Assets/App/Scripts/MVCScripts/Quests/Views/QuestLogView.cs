using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLogView : MonoBehaviour
{
  [Header("Controller reference")]
  [SerializeField] private QuestLogController questLogController;

  [SerializeField] private Text questName;
  [SerializeField] private Text questDescription;
   public GameObject questLogUI;
  [SerializeField] private GameObject questButtonPrefab;
  [SerializeField] private Transform content;
  //[SerializeField] private Toggle isQuestFinished;

  public void SetQuestLogUI(QuestBaseSO quest) {
    questName.text = quest.questName;
    questDescription.text = quest.questDescription;
  }
  public void AddQuestToLog(QuestBaseSO quest) {
    var questButton = Instantiate(questButtonPrefab, content);
    questButton.GetComponent<QuestLogButton>().SetQuest(quest);
  }
  // <public void OnQuestLogButtonPressed() {
  //   QuestLogView questLog = GetComponent<QuestLogButton>().quest;
  //   SetQuestLogUI(quest);
  // }>
  
  public void SetQuestToggle(string questName) {
  //   //isQuestFinished.isOn = true;
  //bu
  var button = GetComponentInChildren<QuestLogButton>();
  button.questEnd = true;
  button.setToggle();
  }

}
