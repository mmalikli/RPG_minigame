using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManger : MonoBehaviour
{

  #region  Audio Manager Singleton
  public static AudioManger instance;

  private void Awake() {
    if (instance == null) {
      instance = this;
    } else {
      Destroy(instance.gameObject);
    }
  }
  #endregion

  [SerializeField] private AudioSource audioSource;

  ///<summary>
  /// This method is used to play character Talk Sound
  ///</summary>
  public void PlayClip(AudioClip clip) {
    audioSource.PlayOneShot(clip);
  }
}
