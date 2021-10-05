using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class s_GunSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject bullet;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform gun;
    //gun setting
    #region Gun Setting
    [SerializeField] private int bulletHolder;
    private int bulletHolderMax;
    [SerializeField] private GameObject bulletGui;
    #endregion
    void Start()
    {
        bulletGui = GameObject.FindGameObjectWithTag("BulletGui");
        bulletHolderMax = bulletHolder;
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
        bulletGui.GetComponent<Text>().text = bulletHolder.ToString();
    }
    
}
