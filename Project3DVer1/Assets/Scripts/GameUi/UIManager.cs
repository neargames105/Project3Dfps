using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    //
    [SerializeField] private int LevelIndex;

    [SerializeField] private GameObject panelComplete;
    [SerializeField] private GameObject panelGameOver;
    //
    private const string LEVEL_INDEX = "LEVEL_INDEX";
    private void Start()
    {
        LevelIndex = PlayerPrefs.GetInt(LEVEL_INDEX, 0);
        //
        s_LevelManage.Instance.onGameOver += OnGameOver;
        s_LevelManage.Instance.onGameWin += OnGameWin;
        //
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
    public void OnGameOver()
    {
        panelGameOver.SetActive(true);
    }
    public void OnGameWin()
    {
        panelComplete.SetActive(true);
    }
}
