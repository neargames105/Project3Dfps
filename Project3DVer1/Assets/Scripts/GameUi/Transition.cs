using UnityEngine;

public class Transition : Singleton<Transition>
{
    private GameObject PanelTrans;
    private GameObject Player;
    private void Awake()
    {
        PanelTrans = GameObject.FindGameObjectWithTag("PanelTrans");
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Start()
    {
        if (Player)
        {
            CloseTrans();
            Player.GetComponent<PlayerMovement>().enabled = false;
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
        Player.GetComponent<PlayerMovement>().enabled = true;
    }


}
