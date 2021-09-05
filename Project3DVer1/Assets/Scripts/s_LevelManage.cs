using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class s_LevelManage : MonoBehaviour
{
    // Start is called before the first frame update
    public static int EnemyCount;
    [SerializeField] private int EnemyCountShow;
    [SerializeField] private GameObject LevelCompletePanel;

    [SerializeField] private GameObject Player;

    [SerializeField] private int LevelIndex;
    [SerializeField] private GameObject[] LevelScene;
    private void Awake()
    {
        LevelIndex = PlayerPrefs.GetInt("LevelIndex", 0);
        LevelIndex = Mathf.Clamp(LevelIndex, 0, LevelScene.Length-1);
        Instantiate(LevelScene[LevelIndex]);
    }
    void Start()
    {
        EnemyCount = EnemyCountShow;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyCount <=0)
        {
            //game next level
            LevelCompletePanel.SetActive(true);
            Player.GetComponent<s_PlayerMovement>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;


        }
    }
    public void OnNextLevel()
    {
        LevelIndex += 1;
        PlayerPrefs.SetInt("LevelIndex", LevelIndex);
    }
    public void OnLoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
