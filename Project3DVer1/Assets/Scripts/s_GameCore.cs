using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_GameCore : Singleton<s_GameCore>
{
    // Start is called before the first frame update
    [HideInInspector] public bool action;
    [HideInInspector] public Camera cam;

    public GunSystem gunSystem;
    public Transform gunTrans;
    public Transform gunHolder;

    public ParticleSystem gunFlash;
    public void Awake()
    {
        cam = Camera.main;
    }
    public void Update()
    {
        //TimeControl();
        if (Input.GetMouseButtonDown(0) && s_LevelManage.Instance.canAction)
        {
            gunSystem.Fire(gunTrans.position , gunTrans.rotation);
            gunFlash.Play();
        }
        if (Input.GetKeyDown(KeyCode.E) && gunSystem == null)
        {
            gunSystem.PickUpWeapon();
        }
        if (Input.GetMouseButtonDown(1) && gunSystem != null)
        {
            gunSystem.ThrowWeapon(cam.transform.forward);
        }
    }
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
