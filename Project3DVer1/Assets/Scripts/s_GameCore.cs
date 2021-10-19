using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_GameCore : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public bool action;
    [HideInInspector] public Camera cam;
    public void TimeControl()
    {
        //time control
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        float time = (x != 0 || y != 0) ? 1f : 0.03f;
        float lerpTime = (x != 0 || y != 0) ? 0.05f : 0.5f;
        time = action ? 1 : time;
        lerpTime = action ? .1f : lerpTime;
        Time.timeScale = Mathf.Lerp(Time.timeScale, time, lerpTime);
    }
    public IEnumerator ActionE(float time)
    {
        action = true;
        yield return new WaitForSecondsRealtime(time);
        action = false;
    }
}
