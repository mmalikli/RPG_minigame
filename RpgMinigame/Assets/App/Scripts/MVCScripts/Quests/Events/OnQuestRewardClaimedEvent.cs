using DynamicBox.EventManagement;


public class OnQuestRewardClaimedEvent : GameEvent
{
  public ItemBaseSO claimedItem;
  public string questName;
  public int claimedCoins;
  public int claimedExperience;

  public OnQuestRewardClaimedEvent(string _questName,ItemBaseSO _claimedItem, int _claimedCoins, int _claimedExperience) {
    claimedItem = _claimedItem;
    claimedCoins = _claimedCoins;
    claimedExperience = _claimedExperience;
    questName = _questName;
  }
}
