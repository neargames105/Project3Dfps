using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemBase : MonoBehaviour
{
    [HideInInspector] public Rigidbody rb;
    public float throwForced;

    public GameObject destroyPs;
    public virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public virtual void Start()
    {
        rb.isKinematic = true;
    }
    public virtual void PickUpItem()
    {
        rb.isKinematic = true;
        transform.DOLocalMove(Vector3.zero, .25f).SetEase(Ease.OutBack).SetUpdate(true);
        transform.DOLocalRotate(Vector3.zero, .25f).SetUpdate(true);
    }
    public void ThrowItem(Vector3 direction)
    {
        //
        s_GameCore.Instance.gunSystem = null;
        s_GameCore.Instance.item = null;
        //
        transform.parent = null;
        rb.isKinematic = false;
        var random = Random.Range(-1f, 1f);
        rb.AddForce(direction * throwForced, ForceMode.Impulse);
        rb.AddTorque(new Vector3(random, random, random) * 10f);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<Enemy>().Dead();
            Destroy(gameObject);
        }
        if (collision.transform.CompareTag("Wall"))
        {
            if (Mathf.Abs(rb.velocity.z) > 0.5f)
            {
                Destroy(gameObject);
                GameObject g = Instantiate(destroyPs, transform.position, transform.rotation);
                Destroy(g, 2f);
            }
            
        }
    }
}
