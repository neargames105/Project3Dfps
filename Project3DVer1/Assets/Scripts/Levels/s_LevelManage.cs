using UnityEngine;
using UnityEngine.Events;
public class s_LevelManage : Singleton<s_LevelManage>
{
    public bool canAction { get; private set; } = true;

    private GameObject player;
    private PlayerMovement _playerMovement;

    //event
    public UnityAction onGameWin;
    public UnityAction onGameOver;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _playerMovement = player.GetComponent<PlayerMovement>();
    }
    private void SetGameMode(bool canAction, bool canMove, int scaleTime)
    {
        this.canAction = canAction;
        _playerMovement.enabled = canMove;
        Time.timeScale = scaleTime;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void GameOver()
    {
        onGameOver?.Invoke();
        SetGameMode(false, false, 1);
    }

    public void GameWin()
    {
        onGameWin?.Invoke();
        SetGameMode(false, false, 1);
    }
    public void EnemyCountToLevel()
    {
        var enemyRemain = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemyRemain.Length-1 <= 0)
        {
            GameWin();
        }
    }




}
