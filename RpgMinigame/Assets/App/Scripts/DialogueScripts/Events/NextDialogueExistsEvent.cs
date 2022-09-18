using DynamicBox.EventManagement;

public class NextDialogueExistsEvent : GameEvent
{
  public DialogueBase nextDialogue;

  public NextDialogueExistsEvent(DialogueBase _nextDialogue) {
    nextDialogue = _nextDialogue;
  }
}
