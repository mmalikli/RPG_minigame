using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string firstStart;

    //public GameObject loadingScreen, loadingIcon;
   // public Text loadingText;
    public void OpenGame()
    {
        SceneManager.LoadScene(firstStart);
        //StartCoroutine(LoadStart());
    }


    public void QuitGame()
    {
        Application.Quit();
    }
    



}