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
    Debug.Log(currentQuestHolder.questName);
    EventManager.Instance.Raise(new OnQuestAcceptedEvent(currentQuestHolder));  

  }
  public void OnQuestDeclinedButton() {
    currentQuestHolder = null;
    // I don't need the OnQuestDeclinedEvent right now...
    questUIView.CloseQuestUI();
  }

  private void OnQuestReceivedEventHandler(OnQuestReceivedEvent eventDetails) {
    currentQuestHolder = eventDetails.receivedQuest;
    questUIView.SetQuestUI(currentQuestHolder);
  }
}
