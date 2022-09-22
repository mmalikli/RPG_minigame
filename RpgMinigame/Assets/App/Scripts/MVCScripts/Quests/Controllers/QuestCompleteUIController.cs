using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;

public class QuestCompleteUIController : MonoBehaviour
{
  private ItemBaseSO receivedItem;

  private void OnEnable() {
    EventManager.Instance.AddListener<OnQuestRewardClaimedEvent>(OnQuestRewardClaimedEventHandler);
  } 
  private void OnDisable() {
    EventManager.Instance.RemoveListener<OnQuestRewardClaimedEvent>(OnQuestRewardClaimedEventHandler);
  }

  [Header("View reference")]
  [SerializeField] private QuestCompleteUIView questCompleteUIView;

  private void OnQuestRewardClaimedEventHandler(OnQuestRewardClaimedEvent eventDetails) {
    receivedItem = eventDetails.claimedItem;
    questCompleteUIView.SetViewUI(eventDetails.questName, eventDetails.claimedItem);
  }

  public void OnClaimedButtonPressed() {
    //Send Items to the inventory; will listen to the ClaimedRewardsEvent
    EventManager.Instance.Raise(new OnItemSendToInventory(receivedItem));
    questCompleteUIView.CloseViewUI();
    //EventManager.Instance.Raise<new OnQuestRewardClaimedEvent
  }
}
