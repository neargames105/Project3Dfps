using UnityEngine;
public class s_Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float bulletSpeed;
    [SerializeField] private GameObject _destroyFX;
    private void FixedUpdate()
    {
        transform.position += bulletSpeed * Time.fixedDeltaTime * transform.forward;
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
            GameObject destroyFX = Instantiate(_destroyFX);
            destroyFX.transform.position = transform.position;
            Destroy(destroyFX, 1f);
            Destroy(gameObject); 
        }
        else if (collision.collider.CompareTag("Player"))
        {
            s_LevelManage.Instance.GameOver();
            Destroy(gameObject);
        }
    }
}
