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
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.localPosition = gun.position;
        newBullet.transform.localRotation = gun.rotation;
    }
    public void Dead()
    {
        Instantiate(deadEffect);
        deadEffect.transform.position = transform.position;
        deadEffect.transform.rotation = transform.rotation;
        //
        EnemyCountToLevel();
        //
        Destroy(gameObject);
        
    }
    void EnemyCountToLevel()
    {
        s_LevelManage.EnemyCount -= 1;
    }
}
