using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float bulletSpeed;
    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            collision.transform.GetComponent<s_Enemy>().dead();
            Destroy(gameObject);
            

        }
        else if (collision.collider.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
