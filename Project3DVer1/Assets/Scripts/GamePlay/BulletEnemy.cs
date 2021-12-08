using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] [Range(-1f , 1f)] private float randomDirection;
    private Vector3 rdDirection;
    private void Start()
    {
        var random = Random.Range(-randomDirection, randomDirection);
        rdDirection = new Vector3(random, random, random);
    }
    private void Update()
    {
        transform.position += bulletSpeed * Time.deltaTime * (transform.forward + rdDirection) ;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("Player"))
        {
            s_LevelManage.Instance.GameOver();
            Destroy(gameObject);
        }
    }
}
