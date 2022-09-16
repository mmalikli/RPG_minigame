using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;

public class OptionButton : MonoBehaviour
{
  public DialogueBase NextDialogue {get; set;} 
  
  public void OnOptionButtonPressed() {
    if(NextDialogue != null) {
      EventManager.Instance.Raise(new NextDialogueExistsEvent(NextDialogue));
    }
  }
}
