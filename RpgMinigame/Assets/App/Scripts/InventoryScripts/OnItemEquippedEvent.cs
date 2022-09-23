using DynamicBox.EventManagement;

public class OnItemEquippedEvent : GameEvent
{
  public ItemBaseSO equippedItem;
  
  public OnItemEquippedEvent(ItemBaseSO _equippedItem) {
    equippedItem = _equippedItem;
  }
}
