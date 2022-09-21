using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LanguageManager : MonoBehaviour
{
 private void OnEnable() {
  EventManager.Instance.AddListener<OnLanguageChangeEvent>(OnLanguageChangeEventHandler);
  EventManager.Instance.AddListener<OnSaveSettingsExistsEvent>(OnSaveSettingsExistsEventHandler);
 }
 private void OnDisable() {
  EventManager.Instance.RemoveListener<OnLanguageChangeEvent>(OnLanguageChangeEventHandler);
  EventManager.Instance.AddListener<OnSaveSettingsExistsEvent>(OnSaveSettingsExistsEventHandler);
 }

 private void OnLanguageChangeEventHandler(OnLanguageChangeEvent eventDetails){
  StartCoroutine(UpdateLanguage(eventDetails.languageIndex));
 }
 private void OnSaveSettingsExistsEventHandler(OnSaveSettingsExistsEvent eventDetails) {
  StartCoroutine(UpdateLanguage(eventDetails.languageIndex));
 }

 IEnumerator UpdateLanguage(int languageIndex) {
  yield return new WaitUntil(() => LocalizationSettings.AvailableLocales.Locales.Count > 0);
  Locale selectedLocale =LocalizationSettings.AvailableLocales.Locales[languageIndex];
  LocalizationSettings.Instance.SetSelectedLocale(selectedLocale);
 }
}
