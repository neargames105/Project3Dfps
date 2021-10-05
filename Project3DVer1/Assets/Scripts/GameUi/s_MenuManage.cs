using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class s_MenuManage : MonoBehaviour
{
    public void PlayGame()
    {
        //Start Transition Animation When Click Button Play and Go to Level[Level Index]
        s_Transition.Instance.StartTrans();
        StartCoroutine(LoadLevel());
    }
    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(PlayerPrefs.GetInt("LevelIndex", 1));
    }
    
    
}
