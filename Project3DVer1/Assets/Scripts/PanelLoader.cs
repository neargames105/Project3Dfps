using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelLoader : MonoBehaviour
{
    public GameObject panelLevel;
    public void LoadPanel()
    {
        panelLevel.SetActive(true);
    }
}
