using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFirst : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameObject CanvansTut;
    void Start()
    {
        Player.GetComponent<PlayerMovement>().enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0;
    }
    public void Already()
    {
        Player.GetComponent<PlayerMovement>().enabled = true;
        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        CanvansTut.SetActive(false);
        
    }
}
