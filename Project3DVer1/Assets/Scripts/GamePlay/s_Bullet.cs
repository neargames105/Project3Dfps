using UnityEngine;
public class s_Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float bulletSpeed;
    private void Update()
    {
        transform.position += bulletSpeed * Time.deltaTime * transform.forward;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<Enemy>().Dead();
            Destroy(gameObject);
        }
        else if (collision.collider.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else if (collision.collider.CompareTag("Player"))
        {
            s_LevelManage.Instance.GameOver();
            Destroy(gameObject);
        }
    }
}
