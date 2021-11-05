using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public GameObject player;
    [SerializeField] private GameObject gunDrop;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject deadEffect;
    //action setting
    [Space(20)]
    public float delay;
    [HideInInspector] public float delayOrigin;
    private Transform gun;
    public bool canDropGun;
    public void Awake()
    {
        gun = transform.Find("Gun");
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Start()
    {
        delayOrigin = delay;
    }
    public void Fire()
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.localPosition = gun.position;
        newBullet.transform.localRotation = gun.rotation;
    }
    public void Dead()
    {
        GameObject DeadEffect = Instantiate(deadEffect);
        DeadEffect.transform.position = this.transform.position;
        DeadEffect.transform.rotation = this.transform.rotation;
        //
        s_LevelManage.Instance.EnemyCountToLevel();
        //
        if (canDropGun)
        {
            DropGunWhenDead();
        }
        Destroy(gameObject);    
    }
    public void DropGunWhenDead()
    {
        GameObject NewDropGun = Instantiate(gunDrop);
        NewDropGun.transform.position = this.transform.position;
    }
    
}
