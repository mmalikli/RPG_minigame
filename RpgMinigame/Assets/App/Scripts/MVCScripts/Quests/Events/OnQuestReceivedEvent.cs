using DynamicBox.EventManagement;

public class OnQuestReceivedEvent : GameEvent
{
  public QuestBaseSO receivedQuest;

  public OnQuestReceivedEvent(QuestBaseSO _receivedQuest) {
    receivedQuest = _receivedQuest;
  }
}
