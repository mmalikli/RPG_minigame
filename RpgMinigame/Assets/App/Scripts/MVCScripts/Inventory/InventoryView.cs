using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
  [Header("Controller reference")]
  [SerializeField] private InventoryController inventoryController;

  [Header("View Parameters")]
  [SerializeField] private InventorySO inventory;

  public GameObject inventoryUI;
  //[SerializeField] private GameObject descriptionBox;

  [SerializeField] private Button[] itemSlotButtons;
  public ButtonItemHolder[] buttonItemHolders;
  [SerializeField] private Button equipButton;
  
  //[SerializeField] private Text itemNameInSlot;
  [SerializeField] private Text itemName;
  [SerializeField] private Text itemDescription;

  private int currentIndex;

  private void Start() {
    //currentIndex = 0;
    //for (int i = 0; i < itemSlotButtons.Length; i++)
    //{
      //buttonItemHolders[i] = itemSlotButtons[i].GetComponent<ButtonItemHolder>();
    //}
    //SetItemDescription(buttonItemHolders[0].itemInSlot);
    UpdateInventoryUI();
  }
  
  public void SaveItemToInventory(ItemBaseSO claimedItem) {
    Debug.Log(claimedItem.itemName);
    Debug.Log(itemSlotButtons.Length);
    //Debug.Log(buttonItemHolders[0].isSlotEmpty);
    for (int i = 0; i < itemSlotButtons.Length; i++)
    {
      //ButtonItemHolder itemData
      if(!buttonItemHolders[i].hasItem) {
        Debug.Log("1");
        //buttonItemHolders[i].isSlotEmpty = false;
        buttonItemHolders[i].SetItemInSlot(claimedItem);
        Debug.Log("2");
        inventory.AddItemToInventorySO(claimedItem);
        currentIndex = i;// i++;
        break;
      }
    }
    UpdateInventoryUI();
  }
  private void UpdateInventoryUI() {
    for (int i = 0; i <inventory.itemHolders.Count; i++)
    {
      buttonItemHolders[i].SetItemInSlot(inventory.itemHolders[i]);
    }
  }
  public void SetUpInventoryUI() {

  }

  // public void OnButtonClicked() {
  //   ItemBaseSO itemInClickedSlot = GetComponent<ButtonItemHolder>().itemInSlot;
  //   SetItemDescription(itemInClickedSlot); 
  // }
  public void SetItemDescription(ItemBaseSO selectedItem) {
    //descriptionBox.SetActive(true);
    if(selectedItem == null) return;
    itemName.text = selectedItem.itemName;
    itemDescription.text = selectedItem.itemDescription;
  }
  public void OnEquipButtonPressed() {
    inventoryController.OnEquipButtonPressed();
  }

  // private void Update() {
  //   if(Input.GetKeyDown(KeyCode.E)) {
  //     inventoryUI.SetActive(!inventoryUI.activeSelf);
  //   }
  // }

  // public void CloseItemDescription() {
  //   descriptionBox.SetActive(false);
  // }
  /*
  public void SetInventoryUI() {

  } 
  */


//   public void SaveItemToInventory(ItemBaseSO claimedItem) {
//     for (int i = 0; i < inventory.itemHolders.Length; i++)
//     {
//       if(inventory.itemHolders[i].isEmpty) {
//         inventory.itemHolders[i].item = claimedItem;
//         inventory.itemHolders[i].isEmpty = false;
//         break;
//       }
//     }
//     UpdateInventoryUI();
//   }
//   public void UpdateInventoryUI() {
//     for (int i = 0; i < inventory.itemHolders.Length; i++)
//     {
//       if(inventory.itemHolders[i].isEmpty) break;
//       Image itemIcon = itemSlotButtons[i].GetComponent<Image>();
//       Text itemNameInSlot = itemSlotButtons[i].GetComponent<Text>();


//       itemIcon.sprite = inventory.itemHolders[i].item.itemIcon;
//       itemNameInSlot.text = inventory.itemHolders[i].item.itemName;
//     }
//   }
//   public int? GetItemIndex (string itemNameInSlot) {
//     for (int i = 0; i < inventory.itemHolders.Length; i++)
//     {
//       //Text itemNameInSlot = itemSlotButtons[i].GetComponent<Text>();
//       if(itemNameInSlot == inventory.itemHolders[i].item.itemName) {
//         return i;
//       }
//     }
//     return null;
//   }
//   public void OnItemSlotButtonClicked() {

//   }
//   private void SetDescriptionMenu() {
//     for (int i = 0; i < inventory.itemHolders.Length; i++)
//     {
//       Text itemNameInSlot = itemSlotButtons[i].GetComponent<Text>();
//       //if()
//      // int itemIndex = GetItemIndex(itemNameInSlot,)
//     }
//     //itemName.text = 
//     //ButtonSlot
//   }

}
