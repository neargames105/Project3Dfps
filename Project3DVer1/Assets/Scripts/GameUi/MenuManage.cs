using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MenuManage : MonoBehaviour
{
    //defaul time of transition is 2f;
    [SerializeField] private Button buttonPlay;
    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
    }
    public void PlayGame()
    {
        //Start Transition Animation When Click Button Play and Go to Level[Level Index]
        Transition.Instance.StartTrans();
        StartCoroutine(LoadLevel());
    }
    public IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(2f);

        var scenename = "LEVEL_INDEX";
        if (PlayerPrefs.HasKey(scenename))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt(scenename));
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
    
    
}
