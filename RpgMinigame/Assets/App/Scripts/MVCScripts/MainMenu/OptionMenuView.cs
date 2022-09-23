using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using OptMenuController;
using TMPro;

namespace OptMenuView {
  public class OptionMenuView : MonoBehaviour
  {
    [Header("Controller reference")]
    [SerializeField] private OptionMenuController optionMenuController;

    [System.Serializable] 
    public class LangItem {
      public string Language;
    }

    [SerializeField] private LangItem[] languages;
    [SerializeField] private Text langLabel;
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private Slider musicSlider, sfxSlider;
    
    [SerializeField] private Text musicLabel, sfxLabel;
    
    private int selectedLangIndex;
    //[Se]

    // public void SetOptionSettings() {
    //   // musicSlider value, index

    // }

    public void OnLanguageSettingsSwitchLeft() {
      selectedLangIndex--;
      if(selectedLangIndex < 0) {
        selectedLangIndex = 0;
      }
      UpdateLangLabel(selectedLangIndex);
      optionMenuController.OnLanguageSettingsSwitch(selectedLangIndex);
    }
    public void OnLanguageSettingsSwitchRight() {
      selectedLangIndex++;
      if (selectedLangIndex > languages.Length - 1 )
      {
        selectedLangIndex = languages.Length - 1;
      }
      UpdateLangLabel(selectedLangIndex);
      optionMenuController.OnLanguageSettingsSwitch(selectedLangIndex);
    }

    public void UpdateLangLabel(int selectedLangIndex) {
      langLabel.text = languages[selectedLangIndex].Language;
    }
    public void OnMusicVolChanged() {
      Debug.Log(musicSlider.value);
      musicLabel.text = (musicSlider.value + 80).ToString();
      audioMixer.SetFloat("Music", Mathf.Clamp(musicSlider.value,-40f,-10f));
      optionMenuController.OnMusicVolChanged(musicSlider.value);
    }
    public void SetMusicVol(float musicSliderValue ) {
      //text and value
      //musicSlider.value = musicSliderValue;
      Debug.Log(musicSliderValue);
      musicLabel.text = (musicSliderValue + 80).ToString();
      musicSlider.value = musicSliderValue;
      audioMixer.SetFloat("Music", Mathf.Clamp(musicSlider.value,-40f,-10f));
      float test;
      audioMixer.GetFloat("Music",out test);
      Debug.Log(test);
    }
    public void OnSFXVolChanged() {
      sfxLabel.text = (sfxSlider.value + 80 ).ToString();
      //sfxSlider.value = sfx
      audioMixer.SetFloat("SFX", Mathf.Clamp(sfxSlider.value,-40f,-10f));
      optionMenuController.OnSFXVolChanged(sfxSlider.value);
    }
    public void SetSFXVol(float sfxSliderValue ) {
      //text and value
      //sfxSlider.value = sfxSliderValue;
      //Debug.Log()
      sfxLabel.text = (sfxSliderValue + 80).ToString();
      sfxSlider.value = sfxSliderValue;
      audioMixer.SetFloat("SFX", Mathf.Clamp(sfxSlider.value,-40f,-10f));
    }
  }
}
