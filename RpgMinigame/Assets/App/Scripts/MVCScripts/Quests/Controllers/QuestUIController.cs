using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;

public class QuestUIController : MonoBehaviour
{
  [Header("View reference")]
  [SerializeField] private QuestUIView questUIView;

  [SerializeField] private QuestBaseSO currentQuestHolder;

  private void OnEnable() {
    EventManager.Instance.AddListener<OnQuestReceivedEvent>(OnQuestReceivedEventHandler);

  }

  private void OnDisable() {
    EventManager.Instance.RemoveListener<OnQuestReceivedEvent>(OnQuestReceivedEventHandler);
  }

  public void OnQuestAcceptedButton() {
    questUIView.CloseQuestUI();
    QuestManager.instance.InQuestUI = false;
    
    EventManager.Instance.Raise(new OnQuestAcceptedEvent(currentQuestHolder));  
    
    //Debug.Log(currentQuestHolder.questName);

  }
  public void OnQuestDeclinedButton() {
    currentQuestHolder = null;
    // I don't need the OnQuestDeclinedEvent right now...
    questUIView.CloseQuestUI();
    QuestManager.instance.InQuestUI = false;
  }

  private void OnQuestReceivedEventHandler(OnQuestReceivedEvent eventDetails) {
    QuestManager.instance.InQuestUI = true;
    currentQuestHolder = eventDetails.receivedQuest;
    questUIView.SetQuestUI(currentQuestHolder);
  }
}
