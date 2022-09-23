using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;

public class InventoryController : MonoBehaviour
{
  private void OnEnable() {
    EventManager.Instance.AddListener<OnItemSendToInventory>(OnItemSendToInventoryHandler);
  }
  private void OnDisable() {
    EventManager.Instance.RemoveListener<OnItemSendToInventory>(OnItemSendToInventoryHandler);
  }
  [Header("View reference")]
  [SerializeField] private InventoryView inventoryView;

  //[SerializeField] private InventorySO inventory;
  public void OnEquipButtonPressed(ItemBaseSO equippedItem) {
    //Raise Event
    Debug.Log("Equipemnt item received");
    Debug.Log(equippedItem.itemName);
    EventManager.Instance.Raise(new OnItemEquippedEvent(equippedItem));
  }
  private void OnItemSendToInventoryHandler(OnItemSendToInventory eventData) {
    Debug.Log("SaveItemToInventory");
    Debug.Log(eventData.savedItem.itemName);
    inventoryView.SaveItemToInventory(eventData.savedItem);
  }
  private void Update() {
    //inventoryView
    if(Input.GetKeyDown(KeyCode.E)) {
    inventoryView.inventoryUI.SetActive(!inventoryView.inventoryUI.activeSelf);
  }
}
}
