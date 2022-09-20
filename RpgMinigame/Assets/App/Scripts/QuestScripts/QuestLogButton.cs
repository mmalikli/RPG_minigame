using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DynamicBox.EventManagement;

public class QuestLogButton : MonoBehaviour
{
  private void OnEnable() {
    //EventManager.Instance.RemoveListener<OnQuestCompletedEvent>(OnQuestCompletedEventHandler);
    Debug.Log("QuestLogButton");
    Debug.Log(questEnd);
    setToggle();
  }
  // private void OnDisable() {
  //   EventManager.Instance.AddListener<OnQuestCompletedEvent>(OnQuestCompletedEventHandler);
  // }
  private void Awake() {
    isQuestFinished.isOn = false;
    isQuestFinished.interactable = false;
    //setToggle
  }
  [HideInInspector] public QuestBaseSO quest;
  [SerializeField] private Text questName;
  [SerializeField] private Toggle isQuestFinished;
  public bool questEnd;

  public void SetQuest(QuestBaseSO _quest) {
    quest = _quest;
    questName.text = _quest.questName;
  }
  public void FinishQuesToggle() {
    isQuestFinished.isOn = true;
  }

  // private void OnQuestCompletedEventHandler(OnQuestCompletedEvent eventDetails) {
  //   if(quest.questName == eventDetails.completedQuest.questName || questEnd) {
  //     Debug.Log("is working");
  //     isQuestFinished.isOn = true;
  //   }
  // }

  public void setToggle() {
    if(questEnd) {
      Debug.Log("is working");
      isQuestFinished.isOn = true;
    }
  }


  public void OnButtonPressed() {
    QuestLogView questLogView = GetComponentInParent<QuestLogView>();
    questLogView.SetQuestLogUI(quest);
  }
  
}
