using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class GunSystem : s_GameCore
{
    // Start is called before the first frame update
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform gunTrans;
    //gun setting
    #region Gun Setting
    [SerializeField] private int bulletHolder;
    private int bulletHolderMax;
    private GameObject bulletGui;
    #endregion
    private void Awake()
    {
        cam = Camera.main;
        bulletGui = GameObject.FindGameObjectWithTag("BulletGui");
    }
    void Start()
    {
        bulletHolderMax = bulletHolder;
        GunSetting();
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.parent != null)
        {
            if (Input.GetMouseButtonDown(0)&& s_LevelManage.Instance.canAction)
            {
                //fire
                Fire();
                bulletHolder--;
                GunSetting();
            }
            
        }   
    }
    void Fire()
    {
        if (bulletHolder <=0)
        {
            Debug.Log("No Bullet");
            return;
        }
        //
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.localPosition = gunTrans.position;
        newBullet.transform.localRotation = gunTrans.rotation;
        //newBullet.transform.localPosition = cam.transform.position + new Vector3(0, 0, 1.42f);
        //newBullet.transform.localRotation = cam.transform.rotation;
        bulletHolder -= 1;
        //shake camera when shot
        Camera.main.transform.DOComplete();
        Camera.main.transform.DOShakePosition(.8f, .04f, 10, 90, false, true).SetUpdate(true);

    }
    void GunSetting()
    {
        bulletHolder = Mathf.Clamp(bulletHolder, 0, bulletHolderMax);
        bulletGui.GetComponent<Text>().text = bulletHolder.ToString();
    }

}
