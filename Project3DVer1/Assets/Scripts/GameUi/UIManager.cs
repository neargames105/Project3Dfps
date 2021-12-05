using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    //
    [SerializeField] private int LevelIndex;

    public GameObject panelComplete;
    public GameObject panelGameOver;
    //
    private const string LEVEL_INDEX = "LEVEL_INDEX";
    private void Start()
    {
        // get level index and clamp value
        LevelIndex = PlayerPrefs.GetInt(LEVEL_INDEX, 0);
        //
        panelComplete.SetActive(false);
        panelGameOver.SetActive(false);

        //
        //Debug.Log(SceneManager.sceneCountInBuildSettings);
    }
    public void OnNextLevel()
    {
        Time.timeScale = 1;
        //Next Level Config
        LevelIndex += 1;
        LevelIndex = Mathf.Clamp(LevelIndex, 0, SceneManager.sceneCountInBuildSettings - 1);
        PlayerPrefs.SetInt(LEVEL_INDEX, LevelIndex);
    }

    public void OnReloadLevel()
    {
        Time.timeScale = 1;
    }
}
