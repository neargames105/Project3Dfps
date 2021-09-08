using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class s_LevelManage : MonoBehaviour
{
    #region LevelManage
    public static int EnemyCount;
    [SerializeField] private int EnemyCountShow;
    [SerializeField] private int LevelIndex;
    #endregion
    #region LevelComplete
    private GameObject LevelCompletePanel;
    private GameObject Player;
    #endregion
    private void Awake()
    {
        //find objects have tag
        Player = GameObject.FindGameObjectWithTag("Player");
        LevelCompletePanel = GameObject.FindGameObjectWithTag("LevelCompleteTag");
        LevelCompletePanel.SetActive(false);
        // get level index and clamp value
        LevelIndex = PlayerPrefs.GetInt("LevelIndex", 0);
        LevelIndex = Mathf.Clamp(LevelIndex, 0, SceneManager.sceneCountInBuildSettings-1);
    }
    void Start()
    {
        //Config Enemy In Level
        EnemyCount = EnemyCountShow;
    }

    void Update()
    {
        if (EnemyCount <=0)
        {
            //Enable Win Panel and Disable Player
            LevelCompletePanel.SetActive(true);
            MouseEnable();
            Player.GetComponent<s_PlayerMovement>().enabled = false;
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
    public void MouseDisable()
    {

    }
    public void MouseEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }



    
}
