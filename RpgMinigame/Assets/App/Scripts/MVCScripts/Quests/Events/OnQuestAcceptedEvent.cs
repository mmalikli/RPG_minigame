using DynamicBox.EventManagement;

public class OnQuestAcceptedEvent : GameEvent
{
  public QuestBaseSO acceptedQuest;

  public OnQuestAcceptedEvent(QuestBaseSO _acceptedQuest) {
    acceptedQuest = _acceptedQuest;
  }
}
