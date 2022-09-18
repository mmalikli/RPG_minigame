using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBaseSO : ScriptableObject
{
  public string itemName;
  public string itemDescription;
  public Sprite itemIcon;

  public int maxStackSize = 1;

}
