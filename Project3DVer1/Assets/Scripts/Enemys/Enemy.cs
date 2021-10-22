using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    public GameObject gunDrop;
    public bool canDropGun;
    [SerializeField] private GameObject bullet;
    private Transform gun;
    [SerializeField] private float delay;
    private float delayOrigin;
    [SerializeField] private GameObject deadEffect;
    private void Awake()
    {
        gun = transform.Find("Gun");
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void Start()
    {
        delayOrigin = delay;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
        //shot
        if (Time.timeScale > 0.05f)
        {
            if (delay <=0)
            {
                Fire();
                delay = delayOrigin;
            }
            else
            {
                delay--;
            }
        }
    }
    void Fire()
    {
        //
        var random = Random.Range(-1f, 1f);
        //
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.localPosition = gun.position;
        newBullet.transform.localRotation = gun.rotation;
    }
    public void Dead()
    {
        GameObject DeadEffect = Instantiate(deadEffect);
        DeadEffect.transform.position = this.transform.position;
        DeadEffect.transform.rotation = this.transform.rotation;
        s_LevelManage.Instance.EnemyCountToLevel();
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
