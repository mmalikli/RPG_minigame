using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUIView : MonoBehaviour
{

  [Header("Controller reference")]
  [SerializeField] private QuestUIController questUIController;

  [Header("View Parameters")]
  [SerializeField] private GameObject questUI;
  [SerializeField] private Text questName;
  [SerializeField] private Text questDescription;

  //[Header("Accept/Decline Buttons")]
  //[SerializeField] private Button Acce
  //newQuest == Received Quest
  //private QuestBaseSO quest;// ??? in sending to the quest log ???

  public void SetQuestUI(QuestBaseSO newQuest) {
    //quest = newQuest;

    questUI.SetActive(true);
    questName.text = newQuest.questName;
    questDescription.text = newQuest.questDescription;
  }
  public void OnQuestAcceptedButton() {
    questUIController.OnQuestAcceptedButton();
  }
  public void OnQuestDeclinedButton() {
    questUIController.OnQuestDeclinedButton();
  }

  public void CloseQuestUI() {
    questUI.SetActive(false);
  }
}
