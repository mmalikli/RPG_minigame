using DynamicBox.EventManagement;

public class OnLanguageChangeEvent : GameEvent
{
  public int languageIndex;

  public OnLanguageChangeEvent(int _languageIndex) {
    languageIndex = _languageIndex;
  }
}