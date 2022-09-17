using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Profile", menuName = "Profiles/Character")]
public class CharacterProfile : ScriptableObject
{
  public Sprite characterPortrait;
  public string characterName;

  [TextArea(1,5)]
  public string characterBiography;
  public AudioClip characterVoice;
}