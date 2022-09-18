using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Option", menuName = "Dialogues/Option Dialogue")]
public class DialogueOptions : DialogueBase
{
  [TextArea(1,10)]
  public string questionText;

  [System.Serializable]
  public class Option {
    public string buttonName;

    public DialogueBase nextDialogue;
    //publuc UnityEvent myEvent;
  }
  public Option[] options; 
}
