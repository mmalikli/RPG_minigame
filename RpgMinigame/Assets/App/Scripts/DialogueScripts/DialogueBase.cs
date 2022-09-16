using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogues/Basic Dialogue")]
public class DialogueBase : ScriptableObject
{
  public DialogueType dialogueType;

  [System.Serializable]
  public class CharacterLine {
    public CharacterProfile character;

    // character speech;
    [TextArea(2,12)]
    public string text;
  }

  [Header("Insert Dialogue Information")]
  // For having several dialogues
  public CharacterLine[] characterLines;
}
