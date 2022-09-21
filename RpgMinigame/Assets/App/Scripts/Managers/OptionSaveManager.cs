using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;
using DynamicBox.SaveManagement;

public class OptionSaveManager : MonoBehaviour
{
  private int languageIndex;
  private float musicVal;
  private float sfxVal;

  private string containerName = "SelectedOptions";
  SaveManager saveManager;

  private void OnEnable() {
    EventManager.Instance.AddListener<OnLanguageChangeEvent>(OnLanguageChangeEventHandler);
    EventManager.Instance.AddListener<OnMusicVolumeChangeEvent>(OnMusicVolumeChangeEventHandler);
    EventManager.Instance.AddListener<OnSFXChangeEvent>(OnSFXChangeEventHandler);
  }
  private void OnDisable() {
    EventManager.Instance.RemoveListener<OnLanguageChangeEvent>(OnLanguageChangeEventHandler);
    EventManager.Instance.RemoveListener<OnMusicVolumeChangeEvent>(OnMusicVolumeChangeEventHandler);
    EventManager.Instance.RemoveListener<OnSFXChangeEvent>(OnSFXChangeEventHandler);
  }

  private void OnLanguageChangeEventHandler(OnLanguageChangeEvent eventDetails) {
    languageIndex = eventDetails.languageIndex;
    UpdateSavedOptionsData();
  }
  private void OnMusicVolumeChangeEventHandler(OnMusicVolumeChangeEvent eventDetails){
    musicVal = eventDetails.MusicValue;
    UpdateSavedOptionsData();
  }
  private void OnSFXChangeEventHandler(OnSFXChangeEvent eventDetails) {
    sfxVal = eventDetails.SFXValue;
    UpdateSavedOptionsData();
  }
  private void Awake() {
    saveManager = new SaveManager(StorageMethod.JSON);
  }
  private void Start() {
    if (saveManager.FileExists(containerName)) {
      Debug.Log("File Exists");
      OptionData savedOptionData = saveManager.LoadFromFile<OptionData>(containerName, null);
      EventManager.Instance.Raise(new OnSaveSettingsExistsEvent(savedOptionData.languageIndex,savedOptionData.musicVal,savedOptionData.sfxVal));
    }
  }
  private void UpdateSavedOptionsData() {
    OptionData savedOptionData = new OptionData(languageIndex,musicVal,sfxVal);
    saveManager.SaveToFile<OptionData>(savedOptionData, containerName);

    Debug.Log(Application.persistentDataPath);
  }
}
