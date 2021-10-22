using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class s_LevelManage : Singleton<s_LevelManage>
{
    #region LevelManage
    public int EnemyCount;
    [SerializeField] private int LevelIndex;
    #endregion
    #region LevelComplete
    private GameObject panelComplete;
    private GameObject panelGameOver;
    private GameObject Player;
    //
    [HideInInspector] public bool canAction;
    #endregion
    private void Awake()
    {
        //find objects have tag
        Player = GameObject.FindGameObjectWithTag("Player");
        panelComplete = GameObject.FindGameObjectWithTag("LevelCompleteTag");
        panelGameOver = GameObject.FindGameObjectWithTag("LevelGameOver");
    }
    private void Start()
    {
        //
        canAction = true;
        // get level index and clamp value
        LevelIndex = PlayerPrefs.GetInt("LevelIndex", 0);
        LevelIndex = Mathf.Clamp(LevelIndex, 0, SceneManager.sceneCountInBuildSettings - 1);
        //
        panelComplete.SetActive(false);
        panelGameOver.SetActive(false);
    }
    public void OnNextLevel()
    {
        Time.timeScale = 1;
        //Next Level Config
        LevelIndex += 1;
        LevelIndex = Mathf.Clamp(LevelIndex, 0, SceneManager.sceneCountInBuildSettings - 1);
        PlayerPrefs.SetInt("LevelIndex", LevelIndex);
        SceneManager.LoadScene(LevelIndex);
    }
    public void OnReloadLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MouseEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void GameOver()
    {
        canAction = false;
        panelGameOver.SetActive(true);
        MouseEnable();
        Player.GetComponent<s_PlayerMovement>().enabled = false;
    }
    public void GameWin()
    {
        //
        canAction = false;
        //Enable Win Panel and Disable Player
        Player.GetComponent<s_PlayerMovement>().enabled = false;
        panelComplete.SetActive(true);
        MouseEnable();
        Debug.Log("gamewin");
    }
    public void EnemyCountToLevel()
    {
        EnemyCount -= 1;
        if (EnemyCount <= 0)
        {
            GameWin();
        }
    }




}
