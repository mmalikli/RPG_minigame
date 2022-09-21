using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
    ///

    public AudioMixer theMixer;



    void Start()
    {
        if (PlayerPrefs.HasKey("Music"))
        {
            theMixer.SetFloat("Music", PlayerPrefs.GetFloat("Music"));

        }

        if (PlayerPrefs.HasKey("SFX"))
        {
            theMixer.SetFloat("SFX", PlayerPrefs.GetFloat("SFX"));

        }
    }
    public void PlayClip(AudioClip clip) {
    audioSource.PlayOneShot(clip);
  }
}
