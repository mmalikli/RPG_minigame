using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public LangItem[] languages;

    public int selectedLang;

    public Text langLabel;

    public AudioMixer theMixer;

    public Slider musicSlider, sfxSlider;
    public Text musicLabel, sfxLabel;



    private void Start()
    {
        if (PlayerPrefs.HasKey("Music"))
        {
            theMixer.SetFloat("Music", PlayerPrefs.GetFloat("Music"));
            musicSlider.value = PlayerPrefs.GetFloat("Music");
            musicLabel.text = (musicSlider.value + 80).ToString();
        }

        if (PlayerPrefs.HasKey("SFX"))
        {
            theMixer.SetFloat("SFX", PlayerPrefs.GetFloat("SFX"));
            sfxSlider.value = PlayerPrefs.GetFloat("SFX");
            sfxLabel.text = (sfxSlider.value + 80).ToString();
        }



    }


    public void langLeft()
    {
        selectedLang--;

        if (selectedLang < 0)
        {
            selectedLang = 0;
        }

        updateLangLabel();
    }
    public void langRight()
    {
        selectedLang++;

        if (selectedLang > languages.Length - 1)
        {
            selectedLang = languages.Length - 1;
        }

        updateLangLabel();
    }

    public void updateLangLabel()
    {
        langLabel.text = languages[selectedLang].Language;
    }


    [System.Serializable]
    public class LangItem
    {
        public string Language;
    }

    public void setMusicVol()
    {
        musicLabel.text = (musicSlider.value + 80).ToString();

        theMixer.SetFloat("Music", musicSlider.value);

        PlayerPrefs.SetFloat("Music", musicSlider.value);
    }
    public void setSFXVol()
    {
        sfxLabel.text = (sfxSlider.value + 80).ToString();

        theMixer.SetFloat("SFX", sfxSlider.value);

        PlayerPrefs.SetFloat("SFX", sfxSlider.value);

    }

}