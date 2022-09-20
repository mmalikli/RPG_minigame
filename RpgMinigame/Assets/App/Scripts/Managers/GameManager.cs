using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;

  private void Awake() {
    if(instance == null) {
      instance = this;
    }

    allDialogueTriggers = FindObjectsOfType<DialogueTrigger>();
  }

  public Transform player;

  public DialogueTrigger[] allDialogueTriggers;
}
