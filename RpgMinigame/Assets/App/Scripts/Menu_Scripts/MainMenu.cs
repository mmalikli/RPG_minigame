using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string firstStart;

    public GameObject loadingScreen, loadingIcon;
    public Text loadingText;
    public void OpenGame()
    {
        //SceneManager.LoadScene(firstStart);
        StartCoroutine(LoadStart());
    }


    public void QuitGame()
    {
        Application.Quit();
    }
    public IEnumerator LoadStart()
    {
        loadingScreen.SetActive(true);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(firstStart);

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= .9f)
            {
                loadingText.text = "Press any key to continue";
                loadingIcon.SetActive(false);

                if (Input.anyKeyDown)
                {
                    asyncLoad.allowSceneActivation = true;

                    //Time.timeScale = 1f;
                }
            }

            yield return null;
        }
    }



}