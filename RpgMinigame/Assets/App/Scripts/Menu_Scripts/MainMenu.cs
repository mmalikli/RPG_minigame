using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstStart;
    public void OpenGame()
    {
        SceneManager.LoadScene(firstStart);
    }


    public void QuitGame()
    {
        Application.Quit();
    }


}