using UnityEngine;
using DynamicBox.EventManagement;

public class QuestManager : MonoBehaviour
{
  private void OnEnable() {
    EventManager.Instance.AddListener<OnQuestAcceptedEvent>(OnQuestAcceptedEventHandler);    
  }
  private void OnDisable() {
    EventManager.Instance.RemoveListener<OnQuestAcceptedEvent>(OnQuestAcceptedEventHandler);    
  }
  public QuestBaseSO CurrentQuest { get; set;}

  private void OnQuestAcceptedEventHandler(OnQuestAcceptedEvent eventDetails) {
    //Debug.Log("Received"+eventDetails.acceptedQuest.questName);
    CurrentQuest = eventDetails.acceptedQuest;
    //Debug.Log("Quest Started QM");
    CurrentQuest.StartQuest();
  }
}
