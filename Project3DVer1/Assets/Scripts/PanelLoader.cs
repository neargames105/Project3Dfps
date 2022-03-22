using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelLoader : MonoBehaviour
{
    public void LoadPanel(GameObject panelAction)
    {
        panelAction.SetActive(true);
    }
    public void ClosePanel(GameObject panelAction)
    {
        panelAction.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
