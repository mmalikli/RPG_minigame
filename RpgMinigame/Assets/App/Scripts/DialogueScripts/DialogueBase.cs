using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue/Basic Dialogue")]
public class DialogueBase : ScriptableObject
{
  [System.Serializable]
  public class Info {
    public CharacterProfile character;

    // character speech;
    [TextArea(2,12)]
    public string text;
  }

  [Header("Insert Dialogue Information")]
  // For having several dialogues
  public Info[] dialogue;
}
