using DynamicBox.EventManagement;

public class OnItemSendToInventory : GameEvent
{
  public ItemBaseSO savedItem;
  public OnItemSendToInventory(ItemBaseSO _savedItem) {
    savedItem = _savedItem;
  }
}
