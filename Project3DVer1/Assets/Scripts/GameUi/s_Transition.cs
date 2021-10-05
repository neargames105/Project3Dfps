using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class s_Transition : MonoBehaviour
{
    private GameObject PanelTrans;
    private GameObject Player;
    public static s_Transition Instance;
    private void Awake()
    {
        PanelTrans = GameObject.FindGameObjectWithTag("PanelTrans");
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Start()
    {
        Instance = this;
        if (Player != null)
        {
            CloseTrans();
            Player.GetComponent<s_PlayerMovement>().enabled = false;
            Invoke("PlayerStart", 1f);
        }
    }
    public void StartTrans()
    {
        PanelTrans.GetComponent<Animator>().SetTrigger("Transition");
    }
    public void CloseTrans()
    {
        PanelTrans.GetComponent<Animator>().SetTrigger("CloseTransition");
    }
    private void PlayerStart()
    {
        Player.GetComponent<s_PlayerMovement>().enabled = true;
    }


}
