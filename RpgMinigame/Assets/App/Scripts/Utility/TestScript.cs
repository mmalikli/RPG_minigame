using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
  public QuestBaseSO quest;

  private void Start() {
    quest.StartQuest();
  }
}
