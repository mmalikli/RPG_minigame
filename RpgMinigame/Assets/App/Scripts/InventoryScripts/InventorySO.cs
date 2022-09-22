using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Inventory", menuName = "Inventory")]
public class InventorySO : ScriptableObject
{
  private void OnEnable() {
    Debug.Log("Inventory Loaded and Cleared for Testing purposes");
    itemHolders.Clear();
    //itemHolders = new List<ItemBaseSO>();
  }
  // private void OnDisable() {
    
  // }
  //[System.Serializable]
  // public class ItemHolder {
  //   public ItemBaseSO item;
  //   //public bool isEmpty = true;
  // }
  //public ItemHolder[] itemHolders;

  public List<ItemBaseSO> itemHolders = new List<ItemBaseSO>();
  public void AddItemToInventorySO(ItemBaseSO addedItem) {
    itemHolders.Add(addedItem);
  }
  // private void OnApplicationQuit() {
  //   itemHolders.Clear();
  // }
}
