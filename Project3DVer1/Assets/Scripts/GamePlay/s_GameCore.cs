using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class s_GameCore : Singleton<s_GameCore>
{
    // Start is called before the first frame update
    [HideInInspector] public bool action;
    [HideInInspector] public Camera cam;
    [Range(0.03f,0.06f)] public float actionTime;
    public GunSystem gunSystem;
    public Transform gunTrans;
    public Transform gunHolder;
    public ParticleSystem gunFlash;
    public LayerMask gun, itemLayer;
    //
    public InteractiveItem item;
    public Transform itemHolder;
    //
    public GameObject textPickUp;
    public void Awake()
    {
        cam = Camera.main;
    }
    public void Update()
    {
        if (s_LevelManage.Instance.canAction)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StopCoroutine(ActionE(actionTime));
                StartCoroutine(ActionE(actionTime));

                if (gunSystem)
                {
                    gunSystem.Fire(gunTrans.position, gunTrans.rotation);
                    gunFlash.Play();
                }
                else if (item)
                {
                    item.ThrowItem(cam.transform.forward);
                }     
            }

            if (Input.GetMouseButtonDown(1))
            {
                StopCoroutine(ActionE(actionTime));
                StartCoroutine(ActionE(actionTime));

                if (gunSystem)
                {
                    gunSystem.ThrowItem(cam.transform.forward);
                }
                else if (item)
                {
                    item.ThrowItem(cam.transform.forward);
                }
            }
        }
        #region RaySetting
        //
        RaycastHit hit;
        //ray to gun
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 100, gun))
        {
            //if ray then active pickuptext
            textPickUp.SetActive(true);
            //gun if gunsystem or item if interactiveitem
            if (Input.GetKeyDown(KeyCode.E) && gunSystem == null && item ==null)
            {
                hit.transform.GetComponent<GunSystem>().PickUpItem();
                textPickUp.SetActive(false);
            }
        }
        //ray to item
        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 100, itemLayer))
        {
            //if ray then active pickuptext
            textPickUp.SetActive(true);
            //gun if gunsystem or item if interactiveitem
            if (Input.GetKeyDown(KeyCode.E) && gunSystem == null && item == null)
            {
                hit.transform.GetComponent<InteractiveItem>().PickUpItem();
                textPickUp.SetActive(false);
            }
        }
        else
        {
            textPickUp.SetActive(false);
        }
        #endregion
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
