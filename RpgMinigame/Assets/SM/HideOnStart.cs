using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnStart : MonoBehaviour
{
  public GameObject obj;
  private void Start() {
    obj.SetActive(false);
    
  }
}
