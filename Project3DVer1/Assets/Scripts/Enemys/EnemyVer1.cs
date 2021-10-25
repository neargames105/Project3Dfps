using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVer1 : Enemy
{
    public void Update()
    {
        transform.LookAt(player.transform.position);
        //shot
        if (Time.timeScale > 0.05f)
        {
            if (delay <= 0)
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
}
