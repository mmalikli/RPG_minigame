using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestCompleteUIView : MonoBehaviour
{
  [Header("Controller reference")]
  [SerializeField] private QuestCompleteUIController questCompleteUIController;

  [Header("View Parameters")]
  [SerializeField] private Text questName;
  [SerializeField] private GameObject questCompleteBox;
  //[SerializeField] private Button ClaimButton; 
  [SerializeField] private Image rewardImage;

  public void SetViewUI(string _questName, ItemBaseSO item) {
    questCompleteBox.SetActive(true);

    questName.text = _questName;
    rewardImage.sprite = item.itemIcon;
  }

  public void OnClaimedButtonPressed() {
    //CloseViewUI();
    questCompleteUIController.OnClaimedButtonPressed();
  }
  public void CloseViewUI() {
    questCompleteBox.SetActive(false);
  }
}
