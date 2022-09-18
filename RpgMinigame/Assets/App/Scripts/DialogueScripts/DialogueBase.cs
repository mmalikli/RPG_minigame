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

    public EmotionType characterEmotion;
    public void ChangeEmotion() {
      character.Emotion = characterEmotion;
    }
  }

  [Header("Insert Dialogue Information")]
  // For having several dialogues
  public CharacterLine[] characterLines;
}
