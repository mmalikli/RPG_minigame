using UnityEngine;
using DynamicBox.EventManagement;

public class QuestManager : MonoBehaviour
{
  public static QuestManager instance;

  private void Awake() {
    if (instance == null) {
      instance = this;
    } else {
      Destroy(instance.gameObject);
    }
  }


  private void OnEnable() {
    EventManager.Instance.AddListener<OnQuestAcceptedEvent>(OnQuestAcceptedEventHandler);    
  }
  private void OnDisable() {
    EventManager.Instance.RemoveListener<OnQuestAcceptedEvent>(OnQuestAcceptedEventHandler);    
  }
  
  public QuestBaseSO CurrentQuest { get; set;}
  //public bool inQuest;
  public bool InQuestUI {get; set;}

  private void OnQuestAcceptedEventHandler(OnQuestAcceptedEvent eventDetails) {
    //Debug.Log("Received"+eventDetails.acceptedQuest.questName);
    //if(CurrentQuest != null) return;
    // if (inQuest == true) return;
    // inQuest = true;

    CurrentQuest = eventDetails.acceptedQuest;
    //Debug.Log("Quest Started QM");
    CurrentQuest.StartQuest();
  }
}
