using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonItemHolder : MonoBehaviour
{
  [SerializeField] private Image itemIcon;
  [SerializeField] private Text itemName;
  [SerializeField] private Button equipButton;


  public ItemBaseSO itemInSlot;
  public bool hasItem;

  // private void Awake() {
  //   isSlotEmpty = true;
  // }

  public void SetItemInSlot(ItemBaseSO addedItem) {
    itemIcon.sprite = addedItem.itemIcon;
    itemName.text = addedItem.itemName;
    itemInSlot = addedItem;
    hasItem = true;
  }
  // public ItemBaseSO GetItemInSlot() {
  //   return itemInSlot;
  // }
  public void OnButtonClick() {
    InventoryView inventoryView = GetComponentInParent<InventoryView>();
    inventoryView.SetItemDescription(itemInSlot);
    equipButton.GetComponent<EqupButtonHelper>().selectedItem = itemInSlot;
  }
  // public void OnEquipButtonClicked() {
  //   InventoryView inventoryView = GetComponentInParent<InventoryView>();
  //   Debug.Log(itemInSlot.itemName);
  //   inventoryView.OnEquipButtonPressed(itemInSlot);
  // }
}
