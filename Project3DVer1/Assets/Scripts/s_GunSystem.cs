using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class s_GunSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject bullet;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform gun;
    //gun setting
    #region Gun Setting
    [SerializeField] private int bulletHolder;
    [SerializeField] private int bulletHolderMax;
    [SerializeField] private Text bulletGui;
    #endregion

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GunSetting();
        if (Input.GetMouseButtonDown(0) && bulletHolder>0)
        {
            //fire
            Fire();
            bulletHolder--;
            Camera.main.transform.DOComplete();
            Camera.main.transform.DOShakePosition(.2f, .01f, 10, 90, false, true).SetUpdate(true);

        }
    }
    void Fire()
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.localPosition = gun.position;
        newBullet.transform.localRotation = gun.rotation;
    }
    void GunSetting()
    {
        if (bulletHolder >= bulletHolderMax)
        {
            bulletHolder = bulletHolderMax;
        }
        if (bulletHolder <=0)
        {
            bulletHolder = 0;
        }
        bulletGui.text = bulletHolder.ToString();
    }
}
