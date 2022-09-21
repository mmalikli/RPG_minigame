using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OptMenuView;
using DynamicBox.EventManagement;
//using 

namespace OptMenuController {
  public class OptionMenuController : MonoBehaviour
  {
    [Header("View reference")]
    [SerializeField] private OptionMenuView optionMenuView;


    private void OnEnable() {
      EventManager.Instance.AddListener<OnSaveSettingsExistsEvent>(OnSaveSettingsExistsEventHandler); 
    } 
    private void OnDisable() {
      EventManager.Instance.RemoveListener<OnSaveSettingsExistsEvent>(OnSaveSettingsExistsEventHandler);
    }

    public void OnLanguageSettingsSwitch(int languageIndex) {
      //Raise Language and Save
      Debug.Log("Language Changed Event Raised");
      EventManager.Instance.Raise(new OnLanguageChangeEvent(languageIndex));
    }
    public void OnMusicVolChanged(float musicValue) {
      //Raise Save
      EventManager.Instance.Raise(new OnMusicVolumeChangeEvent(musicValue));
    }
    public void OnSFXVolChanged(float sfxValue) {
      //Raise Save
      EventManager.Instance.Raise(new OnSFXChangeEvent(sfxValue));
    }
    private void OnSaveSettingsExistsEventHandler(OnSaveSettingsExistsEvent eventDetails) {
      optionMenuView.UpdateLangLabel(eventDetails.languageIndex);
      optionMenuView.SetMusicVol(eventDetails.musicVal);
      optionMenuView.SetSFXVol(eventDetails.sfxVal);
    } 
  }
}
