using UnityEngine;
public class s_LevelManage : Singleton<s_LevelManage>
{
    public int EnemyCount;
    [HideInInspector] public bool canAction;
    public GameObject Player;
    private void Start()
    {
        canAction = true;
    }
    public void GameOver()
    {
        canAction = false;
        UIManager.Instance.panelGameOver.SetActive(true);
        Player.GetComponent<s_PlayerMovement>().enabled = false;
        //
        MouseEnable();
    }

    public void GameWin()
    {
        canAction = false;
        Player.GetComponent<s_PlayerMovement>().enabled = false;
        UIManager.Instance.panelComplete.SetActive(true);
        //
        MouseEnable();
    }
    public void MouseEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void EnemyCountToLevel()
    {
        EnemyCount -= 1;
        //if enemy <=0 the go to win
        if (EnemyCount <= 0)
        {
            GameWin();
        }
    }




}
