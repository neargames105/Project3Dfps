using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s_LevelManage : MonoBehaviour
{
    // Start is called before the first frame update
    public static int EnemyCount;
    [SerializeField] private int EnemyCountShow;
    [SerializeField] private GameObject LevelCompletePanel;

    [SerializeField] private GameObject Player;
    void Start()
    {
        EnemyCount = EnemyCountShow;

        //
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
}
