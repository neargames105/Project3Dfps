using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class s_GunSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject bullet;
    private Camera cam;
    [SerializeField] private Transform gun;
    //gun setting
    #region Gun Setting
    [SerializeField] private int bulletHolder;
    private int bulletHolderMax;
    [SerializeField] private GameObject bulletGui;
    //[SerializeField]
    #endregion
    void Start()
    {
        cam = Camera.main;
        bulletHolderMax = bulletHolder;
        GunSetting();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //fire
            Fire();
            bulletHolder--;
            GunSetting();
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
        newBullet.transform.localPosition = gun.position;
        newBullet.transform.localRotation = gun.rotation;
        bulletHolder -= 1;
        Camera.main.transform.DOComplete();
        Camera.main.transform.DOShakePosition(.8f, .04f, 10, 90, false, true).SetUpdate(true);

    }
    void GunSetting()
    {
        bulletHolder = Mathf.Clamp(bulletHolder, 0, bulletHolderMax);
        bulletGui.GetComponent<Text>().text = bulletHolder.ToString();
    }
    
}
