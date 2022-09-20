using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;

public class QuestLogController : MonoBehaviour
{
  [Header("View reference")]
  [SerializeField] private QuestLogView questLogView;

  [HideInInspector] public List<QuestBaseSO> completedQuests = new List<QuestBaseSO>();

  private void OnEnable() {
    EventManager.Instance.AddListener<OnQuestAcceptedEvent>(OnQuestAcceptedEventHandler);
    EventManager.Instance.AddListener<OnQuestCompletedEvent>(OnQuestCompletedEventHandler);

  }
  private void OnDisable() {
    EventManager.Instance.RemoveListener<OnQuestAcceptedEvent>(OnQuestAcceptedEventHandler);
    EventManager.Instance.AddListener<OnQuestCompletedEvent>(OnQuestCompletedEventHandler);  
  }

  private void OnQuestAcceptedEventHandler(OnQuestAcceptedEvent eventDetails) {
    
    questLogView.AddQuestToLog(eventDetails.acceptedQuest);
  }

  private void OnQuestCompletedEventHandler(OnQuestCompletedEvent eventDetails) {
    
     questLogView.SetQuestToggle(eventDetails.completedQuest.questName);
   }
  private void Update() {
    if(!DialogueManager.instance.isPlayerInDialogue && Input.GetKeyDown(KeyCode.Tab)) {
      //questLog questLogUI.SetActive(!questLogUI.q);
      questLogView.questLogUI.SetActive(!questLogView.questLogUI.activeSelf);
    }
  }
}
