using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EqupButtonHelper : MonoBehaviour
{
  public ItemBaseSO selectedItem;

  public void OnEquipButtonClicked() {
    InventoryView inventoryView = GetComponentInParent<InventoryView>();
    Debug.Log(selectedItem.itemName);
    inventoryView.OnEquipButtonPressed(selectedItem);
  }
}
