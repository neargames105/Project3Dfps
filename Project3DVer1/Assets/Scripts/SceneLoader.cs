using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : Singleton<SceneLoader>
{
    public Text m_Text;

    public GameObject loadingScreen;

    public void LoadButton(int intOfScene)
    {
        //transition effect
        loadingScreen.SetActive(true);

        Transition.Instance.StartTrans();

        Time.timeScale = 1;

        StartCoroutine(LoadSceneA(intOfScene));
    }
    public IEnumerator LoadSceneA(int intOfScene)
    {
        yield return null;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(intOfScene);

        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            //Output the current progress
            m_Text.text = "Loading progress: " + (asyncOperation.progress * 100) + "%";

            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                //Change the Text to show the Scene is ready
                m_Text.text = "Press the space bar to continue";
                //Wait to you press the space key to activate the Scene
                if (Input.GetKeyDown(KeyCode.Space))
                    //Activate the Scene
                    asyncOperation.allowSceneActivation = true;
            }

            yield return null;


        }
    }
}
