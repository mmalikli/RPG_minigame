using DynamicBox.EventManagement;

public class OnQuestCompletedEvent : GameEvent
{
  public QuestBaseSO completedQuest;

  public OnQuestCompletedEvent(QuestBaseSO _completeQuest) {
    completedQuest = _completeQuest;
  }

}
