using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVer1 : Enemy
{
    public void Update()
    {
        if (delay<=0)
        {
            transform.LookAt(player.transform.position);
            Fire();
            delay = delayOrigin;
        }
        else
        {
            delay -= Time.deltaTime;
        }
    }
}
