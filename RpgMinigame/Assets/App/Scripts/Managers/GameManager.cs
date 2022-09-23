using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;

public class GameManager : MonoBehaviour
{
  private void OnEnable() {
    EventManager.Instance.AddListener<OnItemEquippedEvent>(OnItemEquippedEventHandler);
  }
  private void OnDisable() {
    EventManager.Instance.RemoveListener<OnItemEquippedEvent>(OnItemEquippedEventHandler);
  }
  public static GameManager instance;
  public int playerDamage;

  private void Awake() {
    if(instance == null) {
      instance = this;
    }
    playerDamage = 1;
    allDialogueTriggers = FindObjectsOfType<DialogueTrigger>();
  }

  public Transform player;

  public DialogueTrigger[] allDialogueTriggers;

  private void OnItemEquippedEventHandler(OnItemEquippedEvent eventDetails) {
    Debug.Log(eventDetails.equippedItem.damage);
    playerDamage = eventDetails.equippedItem.damage;
  }
}
