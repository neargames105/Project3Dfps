using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform gun;
    [SerializeField] private float delay, delayOrigin;

    [SerializeField] private GameObject deadEffect;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
        //shot
        if (Time.timeScale == 1f)
        {
            delay--;
            if (delay <=0)
            {
                Fire();
                delay = delayOrigin;
            }
        }
    }
    void Fire()
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.localPosition = gun.position;
        newBullet.transform.localRotation = gun.rotation;
    }
    public void dead()
    {
        GameObject DeadEffect = Instantiate(deadEffect);
        DeadEffect.transform.position = transform.position;
        deadEffect.transform.rotation = transform.rotation;
        //
        EnemyCountToLevel();
        //
        Destroy(gameObject);
        Destroy(DeadEffect, 2f);
        
    }
    void EnemyCountToLevel()
    {
        s_LevelManage.EnemyCount -= 1;
    }
}
