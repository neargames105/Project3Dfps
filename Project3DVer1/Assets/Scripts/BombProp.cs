using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombProp : MonoBehaviour
{
    public GameObject explosion;

    public float exploRadious;

    [SerializeField] private LayerMask _enemy;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            BomExplosion();

            GameObject newBomb = Instantiate(explosion);
            newBomb.transform.position = transform.position;
            newBomb.transform.rotation = transform.rotation;
            Destroy(newBomb, 2f);

            Destroy(gameObject);
        }
        
    }

    private void BomExplosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, exploRadious, _enemy);

        foreach (Collider nearby in colliders)
        {
            Enemy enemy = nearby.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.Dead();
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, exploRadious);
    }
}
