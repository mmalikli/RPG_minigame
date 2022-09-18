using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Profile", menuName = "Profiles/Character")]
public class CharacterProfile : ScriptableObject
{
  private Sprite characterPortrait;
  public string characterName;

  [TextArea(1,5)]
  public string characterBiography;
  public AudioClip characterVoice;

  public Sprite CharacterPortrait {
    get {
      SetEmotionType(Emotion);
      return characterPortrait;
    } 
    set {

    }
  }
  [System.Serializable]
  public class EmotionPortraits {
    public Sprite standard;
    public Sprite happy;
    public Sprite angry;
  }
  public EmotionPortraits emotionPortraits;
  public EmotionType Emotion { get; set;}
  public void SetEmotionType(EmotionType newEmotion) {
    Emotion = newEmotion;
    switch (Emotion)
    {
      case EmotionType.Standard:
        characterPortrait = emotionPortraits.standard;
        break;
      case EmotionType.Happy:
        characterPortrait = emotionPortraits.happy;
        break;
      case EmotionType.Angry:
        characterPortrait = emotionPortraits.angry;
        break;
      default:
        characterPortrait = emotionPortraits.standard;
        break;
    }
  }
}