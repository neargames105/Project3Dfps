using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class s_LevelManage : MonoBehaviour
{
    #region LevelManage
    public int EnemyCount;
    [SerializeField] private int LevelIndex;
    #endregion
    #region LevelComplete
    private GameObject panelComplete;
    private GameObject panelGameOver;
    private GameObject Player;
    #endregion

    public static s_LevelManage Instance;
    private void Awake()
    {
        //find objects have tag
        Player = GameObject.FindGameObjectWithTag("Player");
        panelComplete = GameObject.FindGameObjectWithTag("LevelCompleteTag");
        panelGameOver = GameObject.FindGameObjectWithTag("LevelGameOver");
        panelComplete.SetActive(false);
        panelGameOver.SetActive(false);
        // get level index and clamp value
        LevelIndex = PlayerPrefs.GetInt("LevelIndex", 0);
        LevelIndex = Mathf.Clamp(LevelIndex, 0, SceneManager.sceneCountInBuildSettings-1);
    }
    void Start()
    {
        //
        Instance = this;
    }
    void Update()
    {
        if (EnemyCount <=0)
        {
            //Enable Win Panel and Disable Player
            panelComplete.SetActive(true);
            MouseEnable();
            Player.GetComponent<s_PlayerMovement>().enabled = false;
            Player.GetComponent<s_GunSystem>().enabled = false;
        }
    }
    public void OnNextLevel()
    {
        //Next Level Config
        LevelIndex += 1;
        LevelIndex = Mathf.Clamp(LevelIndex, 0, SceneManager.sceneCountInBuildSettings - 1);
        PlayerPrefs.SetInt("LevelIndex", LevelIndex);
        SceneManager.LoadScene(LevelIndex);
    }
    public void OnReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MouseEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void GameOver()
    {
        panelGameOver.SetActive(true);
        MouseEnable();
        Player.GetComponent<s_PlayerMovement>().enabled = false;
        Player.GetComponent<s_GunSystem>().enabled = false;
    }



    
}
